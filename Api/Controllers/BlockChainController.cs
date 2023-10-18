using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BlockChainController:BaseController
    {
        private readonly IUnitOfWork ? _UnitOfWork;

        private readonly IMapper ? _Mapper;

        public BlockChainController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _Mapper=mapper;
            _UnitOfWork=unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<BlockChainDto>>> get(){
            var blockchain= await _UnitOfWork.BlockChains.GetAllAsync();
            return _Mapper.Map<List<BlockChainDto>>(blockchain);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<BlockChainDto>> get(int id){
            var blockchain= await _UnitOfWork.BlockChains.GetByIdAsync(id);
            if(blockchain==null){
                return NotFound();
            }
            return _Mapper.Map<BlockChainDto>(blockchain);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BlockChainDto>> Post([FromBody]BlockChainDto blockChainDto){
            var blockchain=_Mapper.Map<BlockChain>(blockChainDto);
            _UnitOfWork.BlockChains.Add(blockchain);
            await _UnitOfWork.SaveAsync();
            if(blockchain==null){
                return BadRequest();
            }
            blockChainDto.Id=blockchain.Id;
            return CreatedAtAction(nameof(Post),new{id=blockChainDto.Id},blockChainDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BlockChainDto>> Put(int id,[FromBody]BlockChainDto blockChainDto){
            if(blockChainDto==null)
            return BadRequest();
            if(blockChainDto.Id==0)
                blockChainDto.Id=id;
            if(blockChainDto.Id!=id)
            return NotFound();
            var blockchain=_Mapper.Map<BlockChain>(blockChainDto);
            _UnitOfWork.BlockChains.Update(blockchain);
            await _UnitOfWork.SaveAsync();
            return blockChainDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult>Delete(int id){
            var blockchain= await _UnitOfWork.BlockChains.GetByIdAsync(id);
            if(blockchain==null){
                return NotFound();
            }
            _UnitOfWork.BlockChains.Remove(blockchain);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
}