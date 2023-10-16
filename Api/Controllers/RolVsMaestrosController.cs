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
public class RolVsMaestrosController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolVsMaestrosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolvsMaestroDto>>> Get()
    {
        var roles = await _unitOfWork.RolvsMaestro.GetAllAsync();
        return _mapper.Map<List<RolvsMaestroDto>>(roles);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolvsMaestroDto>> Get(int id)
    {
        var rol = await _unitOfWork.RolvsMaestro.GetByIdAsync(id);
        if (rol == null)
            return NotFound();
        return _mapper.Map<RolvsMaestroDto>(rol);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolvsMaestroDto>> Post([FromBody] RolvsMaestroDto rolVsMaestrosDto)
    {
        var rol = _mapper.Map<RolvsMaestro>(rolVsMaestrosDto);
        _unitOfWork.RolvsMaestro.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null)
            return BadRequest();
        rolVsMaestrosDto.Id = rol.Id;
        return CreatedAtAction(nameof(Post), new { Id = rolVsMaestrosDto.Id }, rolVsMaestrosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolvsMaestroDto>> Put(int id, [FromBody] RolvsMaestroDto rolVsMaestrosDto)
    {
        if (rolVsMaestrosDto == null)
            return BadRequest();
        if (rolVsMaestrosDto.Id == 0)
            rolVsMaestrosDto.Id = id;
        if (rolVsMaestrosDto.Id != id)
            return NotFound();
        var rol = _mapper.Map<RolvsMaestro>(rolVsMaestrosDto);
        _unitOfWork.RolvsMaestro.Update(rol);
        await _unitOfWork.SaveAsync();
        return rolVsMaestrosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var rol = await _unitOfWork.RolvsMaestro.GetByIdAsync(id);
        if (rol == null)
            return NotFound();
        _unitOfWork.RolvsMaestro.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

internal class RolVsMaestro
{
}