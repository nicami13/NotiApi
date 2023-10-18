using System;
using System.Collections;
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
    public class GenericovsSubmodulosController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public GenericovsSubmodulosController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<GenericovsSubmodulosDto>>> get(){
            var GenericovsSubmodulos= await _unitOfWork.GenericosvsSubmodulos.GetAllAsync();
            return _mapper.Map<List<GenericovsSubmodulosDto>>(GenericovsSubmodulos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericovsSubmodulosDto>> get(int id){
            var genericovsSubmodulos = await _unitOfWork.GenericosvsSubmodulos.GetByIdAsync(id);
            if(genericovsSubmodulos == null){
                return NotFound();
            }
            return _mapper.Map<GenericovsSubmodulosDto>(genericovsSubmodulos);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenericovsSubmodulos>> Post([FromBody]GenericovsSubmodulosDto genericovsSubmodulosDto)
        {
            var genericovsSubmodulos= _mapper.Map<GenericovsSubmodulos>(genericovsSubmodulosDto);
            _unitOfWork.GenericosvsSubmodulos.Add(genericovsSubmodulos);
            await _unitOfWork.SaveAsync();
            if(genericovsSubmodulos==null){
                return BadRequest();
            }
            genericovsSubmodulosDto.Id=genericovsSubmodulos.Id;
            return CreatedAtAction(nameof(Post),new {id = genericovsSubmodulosDto.Id}, genericovsSubmodulosDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericovsSubmodulosDto>> Put(int id,[FromBody] GenericovsSubmodulosDto genericovsSubmodulosDto){

            if(genericovsSubmodulosDto== null)
            return BadRequest();
            if(genericovsSubmodulosDto.Id==0)
            genericovsSubmodulosDto.Id=id;
            if(genericovsSubmodulosDto.Id != id)
            return NotFound();
            var genericovssubmodulos=_mapper.Map<Auditoria>(genericovsSubmodulosDto);
            _unitOfWork.Auditorias.Update(genericovssubmodulos);
            await _unitOfWork.SaveAsync();
            return genericovsSubmodulosDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id){
            var genericosvssubmodulos = await _unitOfWork.GenericosvsSubmodulos.GetByIdAsync(id);
            if(genericosvssubmodulos== null)
            {
                return NotFound();
            }
            _unitOfWork.GenericosvsSubmodulos.Remove(genericosvssubmodulos);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}