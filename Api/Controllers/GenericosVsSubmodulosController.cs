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
public class GenericosVsSubmodulosController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenericosVsSubmodulosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GenericovsSubmodulosDto>>> Get()
    {
        var genericos = await _unitOfWork.GenericosvsSubmodulos.GetAllAsync();
        return _mapper.Map<List<GenericovsSubmodulosDto>>(genericos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericovsSubmodulosDto>> Get(int id)
    {
        var genericos = await _unitOfWork.GenericosvsSubmodulos.GetByIdAsync(id);
        if (genericos == null)
            return NotFound();
        return _mapper.Map<GenericovsSubmodulosDto>(genericos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericovsSubmodulos>> Post([FromBody] GenericovsSubmodulosDto genericosDto)
    {
        var genericos = _mapper.Map<GenericovsSubmodulos>(genericosDto);
        if (genericos.FechaCreacion == DateTime.MinValue)
        {
            genericos.FechaCreacion = DateTime.Now;
            genericosDto.FechaCreacion = DateTime.Now;
        }
        if (genericos.FechaModificacion == DateTime.MinValue)
        {
            genericos.FechaModificacion = DateTime.Now;
            genericosDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.GenericosvsSubmodulos.Add(genericos);
        await _unitOfWork.SaveAsync();
        if (genericosDto == null)
            return BadRequest();
        genericosDto.Id = genericos.Id;
        return CreatedAtAction(nameof(Post), new { Id = genericosDto.Id }, genericosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericovsSubmodulosDto>> Put(int id, [FromBody] GenericovsSubmodulosDto genericosDto)
    {
        var genericos = _mapper.Map<GenericovsSubmodulos>(genericosDto);
        if (genericosDto == null)
            return BadRequest();
        if (genericosDto.Id == 0)
            genericosDto.Id = id;
        if (genericosDto.Id != id)
            return BadRequest();
        if (genericos.FechaCreacion == DateTime.MinValue)
        {
            genericos.FechaCreacion = DateTime.Now;
            genericosDto.FechaCreacion = DateTime.Now;
        }
        if (genericos.FechaModificacion == DateTime.MinValue)
        {
            genericos.FechaModificacion = DateTime.Now;
            genericosDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.GenericosvsSubmodulos.Update(genericos);
        await _unitOfWork.SaveAsync();
        return genericosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var genericos = await _unitOfWork.GenericosvsSubmodulos.GetByIdAsync(id);
        if (genericos == null)
            return BadRequest();
        _unitOfWork.GenericosvsSubmodulos.Remove(genericos);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}