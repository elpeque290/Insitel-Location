using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_INSITEL.Models;
public partial class Ubicacione
{
    // Identificador único de la ubicación.
    public int Id { get; set; }

    // Nombre de la ubicación.
    [Required(ErrorMessage = "El campo Ubicacion es obligatorio.")]
    [StringLength(100, ErrorMessage = "El campo Ubicacion debe tener como máximo {1} caracteres.")]
    public string Ubicacion { get; set; } = null!;

    // Longitud geográfica de la ubicación.
    [Required(ErrorMessage = "El campo Longitud es obligatorio.")]
    [Range(-180, 180, ErrorMessage = "La longitud debe estar en el rango de -180 a 180.")]
    [Column(TypeName = "decimal(10, 7)")]
    [DisplayFormat(DataFormatString = "{0:0.#################}")]
    public decimal Longitud { get; set; }

    // Latitud geográfica de la ubicación.
    [Required(ErrorMessage = "El campo Latitud es obligatorio.")]
    [Range(-90, 90, ErrorMessage = "La latitud debe estar en el rango de -90 a 90.")]
    [Column(TypeName = "decimal(9, 6)")]
    [DisplayFormat(DataFormatString = "{0:0.#################}")]
    public decimal Latitud { get; set; }

    // Temperatura actual registrada en la ubicación.
    [Required(ErrorMessage = "El campo TemperaturaActual es obligatorio.")]
    [Range(-999.99, 999.99, ErrorMessage = "La temperatura debe estar en el rango de -999.99 a 999.99.")]
    [Column(TypeName = "decimal(5, 2)")]
    [DisplayFormat(DataFormatString = "{0:0.#################}")]
    public decimal TemperaturaActual { get; set; }

}

