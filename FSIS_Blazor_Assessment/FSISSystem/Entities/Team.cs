﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FSISSystem.Entities;

public partial class Team
{
    [Key]
    public int TeamID { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string TeamName { get; set; }

    [Required]
    [StringLength(75)]
    [Unicode(false)]
    public string Coach { get; set; }

    [Required]
    [StringLength(75)]
    [Unicode(false)]
    public string AssistantCoach { get; set; }

    public int? Wins { get; set; }

    public int? Losses { get; set; }

    [InverseProperty("HomeTeam")]
    public virtual ICollection<Game> GameHomeTeams { get; set; } = new List<Game>();

    [InverseProperty("VisitingTeam")]
    public virtual ICollection<Game> GameVisitingTeams { get; set; } = new List<Game>();

    [InverseProperty("Team")]
    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}