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
public class SubmodulosController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubmodulosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SubmodulosDto>>> Get()
    {
        var submodulos = await _unitOfWork.Submodulos.GetAllAsync();
        return _mapper.Map<List<SubmodulosDto>>(submodulos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SubmodulosDto>> Get(int id)
    {
        var submodulos = await _unitOfWork.Submodulos.GetByIdAsync(id);
        if (submodulos == null)
            return NotFound();
        return _mapper.Map<SubmodulosDto>(submodulos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubmodulosDto>> Post([FromBody] SubmodulosDto submodulosDto)
    {
        var submodulos = _mapper.Map<SubModulos>(submodulosDto);
        _unitOfWork.Submodulos.Add(submodulos);
        await _unitOfWork.SaveAsync();
        if (submodulos == null)
            return BadRequest();
        submodulosDto.Id = submodulos.Id;
        return CreatedAtAction(nameof(Post), new { Id = submodulosDto.Id }, submodulosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SubmodulosDto>> Put(int id, [FromBody] SubmodulosDto submodulosDto)
    {
        if (submodulosDto == null)
            return BadRequest();
        if (submodulosDto.Id == 0)
            submodulosDto.Id = id;
        if (submodulosDto.Id != id)
            return NotFound();
        var submodulos = _mapper.Map<SubModulos>(submodulosDto);
        _unitOfWork.Submodulos.Update(submodulos);
        await _unitOfWork.SaveAsync();
        return submodulosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var submodulos = await _unitOfWork.Submodulos.GetByIdAsync(id);
        if (submodulos == null)
            return NotFound();
        _unitOfWork.Submodulos.Remove(submodulos);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}