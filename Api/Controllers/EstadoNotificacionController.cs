using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class EstadoNotificacionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<EstadoNotificacionDto>>> get(){
            var EstadoNotificacion=await  _unitOfWork.EstadoNotificaciones.GetAllAsync();
            return _mapper.Map<List<EstadoNotificacionDto>>(EstadoNotificacion);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoNotificacionDto>>Get(int id){
            var EstadoNotificacion = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);
            if(EstadoNotificacion==null){
                return NotFound();
            }
            return _mapper.Map<EstadoNotificacionDto>(EstadoNotificacion);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoNotificacion>> Post([FromBody]EstadoNotificacionDto estadoNotificacionDto){
            var EstadoNotificacion= _mapper.Map<EstadoNotificacion>(estadoNotificacionDto);
            _unitOfWork.EstadoNotificaciones.Add(EstadoNotificacion);
            await _unitOfWork.SaveAsync();
            if(EstadoNotificacion==null){
                return BadRequest();
            }
            estadoNotificacionDto.Id=EstadoNotificacion.Id;
            return CreatedAtAction(nameof(Post),new{id= estadoNotificacionDto.Id},estadoNotificacionDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoNotificacionDto>> Put(int id, [FromBody]EstadoNotificacionDto estadoNotificacionDto){
            if(estadoNotificacionDto== null){
                return BadRequest();
            }
            if(estadoNotificacionDto.Id==0)
                estadoNotificacionDto.Id=id;
            if(estadoNotificacionDto.Id!=id)
            return NotFound();
            var estadoNotificacion= _mapper.Map<EstadoNotificacion>(estadoNotificacionDto);            
            _unitOfWork.EstadoNotificaciones.Update(estadoNotificacion);
            await _unitOfWork.SaveAsync();
            return estadoNotificacionDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id ){
            var estadoNotificacion = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);
            if (estadoNotificacion==null){
                return NotFound();
            }
            _unitOfWork.EstadoNotificaciones.Remove(estadoNotificacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}