using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AuditoriaController:BaseController
    {
        private readonly IUnitOfWork ? _UnitOfWork;
        private readonly IMapper ? _mapper;

        public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork=unitOfWork;
            _mapper=mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<AuditoriaDto>>> get()
        {
            var Auditoria=await _UnitOfWork.Auditorias.GetAllAsync();
            return _mapper.Map<List<AuditoriaDto>>(Auditoria);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditoriaDto>> get(int id){
            var Auditoria = await _UnitOfWork.Auditorias.GetByIdAsync(id);
            if(Auditoria == null){
                return NotFound();
            }
            return _mapper.Map<AuditoriaDto>(Auditoria);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Auditoria>> Post([FromBody]AuditoriaDto auditoriaDto)
        {
            var auditoria= _mapper.Map<Auditoria>(auditoriaDto);
            _UnitOfWork.Auditorias.Add(auditoria);
            await _UnitOfWork.SaveAsync();
            if(auditoria==null){
                return BadRequest();
            }
            auditoriaDto.Id=auditoria.Id;
            return CreatedAtAction(nameof(Post),new {id = auditoriaDto.Id}, auditoriaDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditoriaDto>> Put(int id,[FromBody] AuditoriaDto auditoriaDto){

            if(auditoriaDto== null)
            return BadRequest();
            if(auditoriaDto.Id==0)
            auditoriaDto.Id=id;
            if(auditoriaDto.Id != id)
            return NotFound();
            var auditoria=_mapper.Map<Auditoria>(auditoriaDto);
            _UnitOfWork.Auditorias.Update(auditoria);
            await _UnitOfWork.SaveAsync();
            return auditoriaDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
            var auditoria = await _UnitOfWork.Auditorias.GetByIdAsync(id);
            if(auditoria== null)
            {
                return NotFound();
            }
            _UnitOfWork.Auditorias.Remove(auditoria);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }


}

