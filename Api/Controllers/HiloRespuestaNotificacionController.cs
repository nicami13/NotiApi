using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class HiloRespuestaNotificacionController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HiloRespuestaNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<HiloRespuestaNotificaionDto>>> Get()
    {
        var response = await _unitOfWork.HiloRepuestaNotificaciones.GetAllAsync();
        return _mapper.Map<List<HiloRespuestaNotificaionDto>>(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HiloRespuestaNotificaionDto>> Get(int id)
    {
        var response = await _unitOfWork.HiloRepuestaNotificaciones.GetByIdAsync(id);
        if(response == null )
            return NotFound();
        return _mapper.Map<HiloRespuestaNotificaionDto>(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HiloRespuestaNotificacion>> Post([FromBody] HiloRespuestaNotificaionDto hiloDto)
    {
        var hilo = _mapper.Map<HiloRespuestaNotificacion>(hiloDto);
        if (hilo.FechaCreacion == DateTime.MinValue)
        {
            hilo.FechaCreacion = DateTime.Now;
            hiloDto.FechaCreacion = DateTime.Now;
        }
        if (hilo.FechaModificacion == DateTime.MinValue)
        {
            hilo.FechaModificacion = DateTime.Now;
            hiloDto.FechaModificaion = DateTime.Now;
        }
        _unitOfWork.HiloRepuestaNotificaciones.Add(hilo);
        await _unitOfWork.SaveAsync();
        if(hilo == null)
            return BadRequest();
        hiloDto.Id = hilo.Id;
        return CreatedAtAction(nameof(Post), new {Id = hiloDto.Id}, hiloDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HiloRespuestaNotificaionDto>> Put(int id, [FromBody] HiloRespuestaNotificaionDto hiloDto)
    {
        var hilo = _mapper.Map<HiloRespuestaNotificacion>(hiloDto);
        if(hiloDto == null)
            return BadRequest();
        if(hiloDto.Id == 0)
            hiloDto.Id = id;
        if(hiloDto.Id != id)
            return NotFound();
        if (hilo.FechaCreacion == DateTime.MinValue)
        {
            hilo.FechaCreacion = DateTime.Now;
            hiloDto.FechaCreacion = DateTime.Now;
        }
        if (hilo.FechaModificacion == DateTime.MinValue)
        {
            hilo.FechaModificacion = DateTime.Now;
            hiloDto.FechaModificaion = DateTime.Now;
        }
        _unitOfWork.HiloRepuestaNotificaciones.Update(hilo);
        await _unitOfWork.SaveAsync();
        return hiloDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var hilo = await _unitOfWork.HiloRepuestaNotificaciones.GetByIdAsync(id);
        if(hilo == null)
            return NotFound();
        _unitOfWork.HiloRepuestaNotificaciones.Remove(hilo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}