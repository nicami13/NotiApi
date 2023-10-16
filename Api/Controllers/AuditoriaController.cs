using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class AuditoriaController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper) 
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AuditoriaDto>>> Get()
    {
        var auditorias = await _unitOfWork.Auditorias.GetAllAsync();
        return _mapper.Map<List<AuditoriaDto>>(auditorias);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuditoriaDto>> Get(int id)
    {
        var auditorias = await _unitOfWork.Auditorias.GetByIdAsync(id);
        if(auditorias == null)
            return NotFound();
        return _mapper.Map<AuditoriaDto>(auditorias);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Auditoria>> Post([FromBody] AuditoriaDto auditoriaDto)
    {
        var auditoria = _mapper.Map<Auditoria>(auditoriaDto);
         if (auditoria.FechaCreacion == DateTime.MinValue)
        {
            auditoria.FechaCreacion = DateTime.Now;
            auditoriaDto.FechaCreacion = DateTime.Now;
        }
        if (auditoria.FechaModificacion == DateTime.MinValue)
        {
            auditoria.FechaModificacion = DateTime.Now;
            auditoriaDto.FechaModificaion = DateTime.Now;
        }
        _unitOfWork.Auditorias.Add(auditoria);
        await _unitOfWork.SaveAsync();
        if(auditoria == null)
            return BadRequest();
        auditoriaDto.Id = auditoria.Id;
        return CreatedAtAction(nameof(Post), new {Id = auditoriaDto.Id}, auditoriaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuditoriaDto>> Put(int id, [FromBody] AuditoriaDto auditoriaDto)
    {
        var auditoria = _mapper.Map<Auditoria>(auditoriaDto);
        if(auditoriaDto == null)
            return BadRequest();
        if(auditoriaDto.Id == 0)
            auditoriaDto.Id = id;
        if(auditoriaDto.Id != id)
            return NotFound();
        if (auditoria.FechaCreacion == DateTime.MinValue)
        {
            auditoria.FechaCreacion = DateTime.Now;
            auditoriaDto.FechaCreacion = DateTime.Now;
        }
        if (auditoria.FechaModificacion == DateTime.MinValue)
        {
            auditoria.FechaModificacion = DateTime.Now;
            auditoriaDto.FechaModificaion = DateTime.Now;
        }
        _unitOfWork.Auditorias.Add(auditoria);
        await _unitOfWork.SaveAsync();
        return auditoriaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
        if(auditoria == null)
            return NotFound();
        _unitOfWork.Auditorias.Remove(auditoria);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}