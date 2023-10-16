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
public class RolController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolDto>>> Get()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return _mapper.Map<List<RolDto>>(roles);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Get(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null)
            return NotFound();
        return _mapper.Map<RolDto>(rol);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolDto>> Post([FromBody] RolDto rolDto)
    {
        var rol = _mapper.Map<Rol>(rolDto);
        if (rol.FechaCreacion == DateTime.MinValue)
        {
            rol.FechaCreacion = DateTime.Now;
            rolDto.FechaCreacion = DateTime.Now;
        }
        if (rol.FechaModificacion == DateTime.MinValue)
        {
            rol.FechaModificacion = DateTime.Now;
            rolDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.Roles.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null)
            return BadRequest();
        rolDto.Id = rol.Id;
        return CreatedAtAction(nameof(Post), new { Id = rolDto.Id }, rolDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Put(int id, [FromBody] RolDto rolDto)
    {
        if (rolDto == null)
            return BadRequest();
        if (rolDto.Id == 0)
            rolDto.Id = id;
        if (rolDto.Id != id)
            return NotFound();
        var rol = _mapper.Map<Rol>(rolDto);
        _unitOfWork.Roles.Update(rol);
        await _unitOfWork.SaveAsync();
        return rolDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null)
            return NotFound();
        _unitOfWork.Roles.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}