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
public class ModuloNotificacionesController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModuloNotificacionesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ModuloNotificacionesDto>>> Get()
    {
        var modulo = await _unitOfWork.ModuloNotificaciones.GetAllAsync();
        return _mapper.Map<List<ModuloNotificacionesDto>>(modulo);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloNotificacionesDto>> Get(int id)
    {
        var modulo = await _unitOfWork.ModuloNotificaciones.GetByIdAsync(id);
        if (modulo == null)
            return NotFound();
        return _mapper.Map<ModuloNotificacionesDto>(modulo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModuloNotificaciones>> Post([FromBody] ModuloNotificacionesDto moduloNotificacionesDto)
    {
        var modulo = _mapper.Map<ModuloNotificaciones>(moduloNotificacionesDto);
        if (modulo.FechaCreacion == DateTime.MinValue)
        {
            modulo.FechaCreacion = DateTime.Now;
            moduloNotificacionesDto.FechaCreacion = DateTime.Now;
        }
        if (modulo.FechaModificacion == DateTime.MinValue)
        {
            modulo.FechaModificacion = DateTime.Now;
            moduloNotificacionesDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.ModuloNotificaciones.Add(modulo);
        await _unitOfWork.SaveAsync();
        if (modulo == null)
            return BadRequest();
        moduloNotificacionesDto.Id = modulo.Id;
        return CreatedAtAction(nameof(Post), new { Id = moduloNotificacionesDto.Id }, moduloNotificacionesDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModuloNotificacionesDto>> Put(int id, [FromBody] ModuloNotificacionesDto moduloNotificacionesDto)
    {
        var modulo = _mapper.Map<ModuloNotificaciones>(moduloNotificacionesDto);
        if (moduloNotificacionesDto == null)
            return BadRequest();
        if (moduloNotificacionesDto.Id == 0)
            moduloNotificacionesDto.Id = id;
        if (moduloNotificacionesDto.Id != id)
            return NotFound();
        if (modulo.FechaCreacion == DateTime.MinValue)
        {
            modulo.FechaCreacion = DateTime.Now;
            moduloNotificacionesDto.FechaCreacion = DateTime.Now;
        }
        if (modulo.FechaModificacion == DateTime.MinValue)
        {
            modulo.FechaModificacion = DateTime.Now;
            moduloNotificacionesDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.ModuloNotificaciones.Update(modulo);
        await _unitOfWork.SaveAsync();
        return moduloNotificacionesDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var modulo = await _unitOfWork.ModuloNotificaciones.GetByIdAsync(id);
        if (modulo == null)
            return NotFound();
        _unitOfWork.ModuloNotificaciones.Remove(modulo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}