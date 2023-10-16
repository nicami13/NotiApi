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
public class PermisosGenericosController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PermisosGenericosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PermisosGenericosDto>>> Get()
    {
        var permisos = await _unitOfWork.PermisosGenericos.GetAllAsync();
        return _mapper.Map<List<PermisosGenericosDto>>(permisos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermisosGenericosDto>> Get(int id)
    {
        var permiso = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);
        if (permiso == null)
            return NotFound();
        return _mapper.Map<PermisosGenericosDto>(permiso);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PermisosGenericosDto>> Post([FromBody] PermisosGenericosDto permisosGenericosDto)
    {
        var permiso = _mapper.Map<PermisosGenericos>(permisosGenericosDto);
        if (permiso.FechaCreacion == DateTime.MinValue)
        {
            permiso.FechaCreacion = DateTime.Now;
            permisosGenericosDto.FechaCreacion = DateTime.Now;
        }
        if (permiso.FechaModificacion == DateTime.MinValue)
        {
            permiso.FechaModificacion = DateTime.Now;
            permisosGenericosDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.PermisosGenericos.Add(permiso);
        await _unitOfWork.SaveAsync();
        if (permiso == null)
            return BadRequest();
        permisosGenericosDto.Id = permiso.Id;
        return CreatedAtAction(nameof(Post), new { Id = permisosGenericosDto.Id }, permisosGenericosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermisosGenericosDto>> Put(int id, [FromBody] PermisosGenericosDto permisosGenericosDto)
    {
        var permiso = _mapper.Map<PermisosGenericos>(permisosGenericosDto);
        if (permisosGenericosDto == null)
            return BadRequest();
        if (permisosGenericosDto.Id == 0)
            permisosGenericosDto.Id = id;
        if (permisosGenericosDto.Id != id)
            return NotFound();
        if (permiso.FechaCreacion == DateTime.MinValue)
        {
            permiso.FechaCreacion = DateTime.Now;
            permisosGenericosDto.FechaCreacion = DateTime.Now;
        }
        if (permiso.FechaModificacion == DateTime.MinValue)
        {
            permiso.FechaModificacion = DateTime.Now;
            permisosGenericosDto.FechaModificacion = DateTime.Now;
        }
        _unitOfWork.PermisosGenericos.Update(permiso);
        await _unitOfWork.SaveAsync();
        return permisosGenericosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var permiso = await _unitOfWork.PermisosGenericos.GetByIdAsync(id);
        if (permiso == null)
            return NotFound();
        _unitOfWork.PermisosGenericos.Remove(permiso);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}