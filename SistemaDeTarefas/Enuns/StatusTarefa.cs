﻿using System.ComponentModel;

namespace SistemaDeTarefas.Enuns
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3,
    }
}
