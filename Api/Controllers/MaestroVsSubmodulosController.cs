using System;
using System.Collections.Generic;
using System.Linq;
using Api.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class MaestroVsSubmodulosController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MaestroVsSubmodulosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MaestroVsSubmodulosDto>>> Get()
    {
        var maestro = await _unitOfWork.MaestrovsSubmodulos.GetAllAsync();
        return _mapper.Map<List<MaestroVsSubmodulosDto>>(maestro);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaestroVsSubmodulosDto>> Get(int id)
    {
        var maestro = await _unitOfWork.MaestrovsSubmodulos.GetByIdAsync(id);
        if (maestro == null)
            return NotFound();
        return _mapper.Map<MaestroVsSubmodulosDto>(maestro);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MaestrovsSubmodulos>> Post([FromBody] MaestroVsSubmodulosDto maestroVsSubmodulosDto)
    {
        var maestro = _mapper.Map<MaestrovsSubmodulos>(maestroVsSubmodulosDto);
        if (maestro.FechaCreacion == DateTime.MinValue)
        {
            maestro.FechaCreacion = DateTime.Now;
            maestroVsSubmodulosDto.FechaCreacion = DateTime.Now;
        }
        if (maestro.FechaModificacion == DateTime.MinValue)
        {
            maestro.FechaModificacion = DateTime.Now;
            maestroVsSubmodulosDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.MaestrovsSubmodulos.Update(maestro);
        await _unitOfWork.SaveAsync();
        if (maestro == null)
            return BadRequest();
        maestroVsSubmodulosDto.Id = maestro.Id;
        return CreatedAtAction(nameof(Post), new { Id = maestroVsSubmodulosDto.Id }, maestroVsSubmodulosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaestroVsSubmodulosDto>> Put(int id, [FromBody] MaestroVsSubmodulosDto maestroVsSubmodulosDto)
    {
        var maestro = _mapper.Map<MaestrovsSubmodulos>(maestroVsSubmodulosDto);
        if (maestroVsSubmodulosDto == null)
            return BadRequest();
        if (maestroVsSubmodulosDto.Id == 0)
            maestroVsSubmodulosDto.Id = id;
        if (maestroVsSubmodulosDto.Id != id)
            return NotFound();
        if (maestro.FechaCreacion == DateTime.MinValue)
        {
            maestro.FechaCreacion = DateTime.Now;
            maestroVsSubmodulosDto.FechaCreacion = DateTime.Now;
        }
        if (maestro.FechaModificacion == DateTime.MinValue)
        {
            maestro.FechaModificacion = DateTime.Now;
            maestroVsSubmodulosDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.MaestrovsSubmodulos.Update(maestro);
        await _unitOfWork.SaveAsync();
        return maestroVsSubmodulosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var maestro = await _unitOfWork.MaestrovsSubmodulos.GetByIdAsync(id);
        if (maestro == null)
            return NotFound();
        _unitOfWork.MaestrovsSubmodulos.Remove(maestro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

internal class MaestrosVsSubmodulos
{
}