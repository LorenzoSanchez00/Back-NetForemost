using System;
using System.Collections.Generic;

namespace NetforemostAPI.Models;

public partial class SaldoModel
{
    public int? GestorId { get; set; }

    public int? Saldo { get; set; }

    public virtual Gestore? Gestor { get; set; }
}
