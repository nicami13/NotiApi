using Api.Dtos;
using AutoMapper;
using Core.entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class TipoRequerimientoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TipoRequerimientoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoRequerimientoDto>>> Get()
    {
        var tipo = await _unitOfWork.TipoRequerimientos.GetAllAsync();
        return _mapper.Map<List<TipoRequerimientoDto>>(tipo);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoRequerimientoDto>> Get(int id)
    {
        var tipo = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);
        if (tipo == null)
            return NotFound();
        return _mapper.Map<TipoRequerimientoDto>(tipo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoRequerimientoDto>> Post([FromBody] TipoRequerimientoDto tipoRequerimientoDto)
    {
        var tipo = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);
        if (tipo.FechaCreacion == DateTime.MinValue)
        {
            tipo.FechaCreacion = DateTime.Now;
            tipoRequerimientoDto.FechaCreacion = DateTime.Now;
        }
        if (tipo.FechaModificacion == DateTime.MinValue)
        {
            tipo.FechaModificacion = DateTime.Now;
            tipoRequerimientoDto.FechaModificaion = DateTime.Now;
        }
        _unitOfWork.TipoRequerimientos.Add(tipo);
        await _unitOfWork.SaveAsync();
        if (tipo == null)
            return BadRequest();
        tipoRequerimientoDto.Id = tipo.Id;
        return CreatedAtAction(nameof(Post), new { Id = tipoRequerimientoDto.Id }, tipoRequerimientoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoRequerimientoDto>> Put(int id, [FromBody] TipoRequerimientoDto tipoRequerimientoDto)
    {
        var tipo = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);
        if (tipoRequerimientoDto == null)
            return BadRequest();

        if (tipoRequerimientoDto.Id == 0)
            tipoRequerimientoDto.Id = id;
            
        if (tipoRequerimientoDto.Id != id)
            return NotFound();

        if (tipo.FechaCreacion == DateTime.MinValue)
        {
            tipo.FechaCreacion = DateTime.Now;
            tipoRequerimientoDto.FechaCreacion = DateTime.Now;
        }
        if (tipo.FechaModificacion == DateTime.MinValue)
        {
            tipo.FechaModificacion = DateTime.Now;
            tipoRequerimientoDto.FechaModificaion = DateTime.Now;
        }
        _unitOfWork.TipoRequerimientos.Update(tipo);
        await _unitOfWork.SaveAsync();
        return tipoRequerimientoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var tipo = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);
        if (tipo == null)
            return NotFound();
        _unitOfWork.TipoRequerimientos.Remove(tipo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}