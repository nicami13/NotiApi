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
    public class FormatoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public FormatoController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FormatoDto>>> get(){
            var formato= await _unitOfWork.Formatos.GetAllAsync();
            return _mapper.Map<List<FormatoDto>>(formato);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<ActionResult<FormatoDto>> get(int id){
            var formato = await _unitOfWork.Formatos.GetByIdAsync(id);
            if(formato== null){
                return NotFound();
            }
            return _mapper.Map<FormatoDto>(formato);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Formatos>> Post([FromBody]FormatoDto formatoDtoDto){
            var formato =_mapper.Map<Formatos>(formatoDtoDto);
            _unitOfWork.Formatos.Add(formato);
            await _unitOfWork.SaveAsync();
            if(formato==null)
            return BadRequest();
            formatoDtoDto.Id=formato.Id;
            return CreatedAtAction(nameof(Post),new{Id=formatoDtoDto.Id},formatoDtoDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<FormatoDto>>Put(int id,[FromBody] FormatoDto formatoDto){
            if(formatoDto== null)
            return BadRequest();
            if(formatoDto.Id==0)
            formatoDto.Id=id;
            if(formatoDto.Id!=id)
            return NotFound();
            var formato = _mapper.Map<Formatos>(formatoDto);
            _unitOfWork.Formatos.Update(formato);
            await _unitOfWork.SaveAsync();
            return formatoDto;   
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id){
            var formato= await _unitOfWork.Formatos.GetByIdAsync(id);
            if(formato== null)
            return NotFound();
            _unitOfWork.Formatos.Remove(formato);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }



    }
}