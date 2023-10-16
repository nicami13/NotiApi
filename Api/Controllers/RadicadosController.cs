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
public class RadicadosController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RadicadosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RadicadosDto>>> Get()
    {
        var radicados = await _unitOfWork.Radicados.GetAllAsync();
        return _mapper.Map<List<RadicadosDto>>(radicados);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RadicadosDto>> Get(int id)
    {
        var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);
        if (radicado == null)
            return NotFound();
        return _mapper.Map<RadicadosDto>(radicado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RadicadosDto>> Post([FromBody] RadicadosDto radicadosDto)
    {
        var radicado = _mapper.Map<Radicados>(radicadosDto);
        if (radicado.FechaCreacion == DateTime.MinValue)
        {
            radicado.FechaCreacion = DateTime.Now;
            radicadosDto.FechaCreacion = DateTime.Now;
        }
        if (radicado.FechaModificacion == DateTime.MinValue)
        {
            radicado.FechaModificacion = DateTime.Now;
            radicadosDto.FechaModificaion = DateTime.Now;
        }
        _unitOfWork.Radicados.Add(radicado);
        await _unitOfWork.SaveAsync();
        if (radicado == null)
            return BadRequest();
        radicadosDto.Id = radicado.Id;
        return CreatedAtAction(nameof(Post), new { Id = radicadosDto.Id }, radicadosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RadicadosDto>> Put(int id, [FromBody] RadicadosDto radicadosDto)
    {
        var radicado = _mapper.Map<Radicados>(radicadosDto);
        if (radicadosDto == null)
            return BadRequest();
        if (radicadosDto.Id == 0)
            radicadosDto.Id = id;
        if (radicadosDto.Id != id)
            return NotFound();
        if (radicado.FechaCreacion == DateTime.MinValue)
        {
            radicado.FechaCreacion = DateTime.Now;
            radicadosDto.FechaCreacion = DateTime.Now;
        }
        if (radicado.FechaModificacion == DateTime.MinValue)
        {
            radicado.FechaModificacion = DateTime.Now;
            radicadosDto.FechaModificaion = DateTime.Now;
        }
        _unitOfWork.Radicados.Update(radicado);
        await _unitOfWork.SaveAsync();
        return radicadosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);
        if (radicado == null)
            return NotFound();
        _unitOfWork.Radicados.Remove(radicado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}