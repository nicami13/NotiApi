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
public class ModulosMaestrosController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModulosMaestrosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ModulosMaestrosDto>>> Get()
    {
        var modulo = await _unitOfWork.ModulosMaestro.GetAllAsync();
        return _mapper.Map<List<ModulosMaestrosDto>>(modulo);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModulosMaestrosDto>> Get(int id)
    {
        var modulo = await _unitOfWork.ModulosMaestro.GetByIdAsync(id);
        if (modulo == null)
            return NotFound();
        return _mapper.Map<ModulosMaestrosDto>(modulo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModulosMaestrosDto>> Post([FromBody] ModulosMaestrosDto modulosMaestrosDto)
    {
        var modulo = _mapper.Map<ModuloMaestro>(modulosMaestrosDto);
        if (modulo.FechaCreacion == DateTime.MinValue)
        {
            modulo.FechaCreacion = DateTime.Now;
            modulosMaestrosDto.FechaCreacion = DateTime.Now;
        }
        if (modulo.FechaModificacion == DateTime.MinValue)
        {
            modulo.FechaModificacion = DateTime.Now;
            modulosMaestrosDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.ModulosMaestro.Add(modulo);
        await _unitOfWork.SaveAsync();
        if (modulo == null)
            return BadRequest();
        modulosMaestrosDto.Id = modulo.Id;
        return CreatedAtAction(nameof(Post), new { Id = modulosMaestrosDto.Id }, modulosMaestrosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModulosMaestrosDto>> Put(int id, [FromBody] ModulosMaestrosDto modulosMaestrosDto)
    {
        var modulo = _mapper.Map<ModuloMaestro>(modulosMaestrosDto);
        if (modulosMaestrosDto == null)
            return BadRequest();
        if (modulosMaestrosDto.Id == 0)
            modulosMaestrosDto.Id = id;
        if (modulosMaestrosDto.Id != id)
            return NotFound();
        if (modulo.FechaCreacion == DateTime.MinValue)
        {
            modulo.FechaCreacion = DateTime.Now;
            modulosMaestrosDto.FechaCreacion = DateTime.Now;
        }
        if (modulo.FechaModificacion == DateTime.MinValue)
        {
            modulo.FechaModificacion = DateTime.Now;
            modulosMaestrosDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.ModulosMaestro.Update(modulo);
        await _unitOfWork.SaveAsync();
        return modulosMaestrosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var modulo = await _unitOfWork.ModulosMaestro.GetByIdAsync(id);
        if (modulo == null)
            return NotFound();
        _unitOfWork.ModulosMaestro.Remove(modulo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}