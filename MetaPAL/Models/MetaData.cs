﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetaPAL.Models;

/// <summary>
/// Model representing MetaData table for a data file
/// This will grow as more metadata is added to the database
/// Example records include
/// Organism, Human
/// Organism, Mouse
/// Instrument, Orbitrap
/// Instrument, Q-Exactive
/// DissociationType, CID
/// DissociationType, HCD
/// </summary>
[Table("MetaData")]
public class MetaData
{
    [Key]
    public int Id { get; set; } //autogenerated unique id
    public string Name { get; set; }
    public string Value { get; set; }
}