using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoBancasTcc.Domains.Entities
{
    public class Filial
    {
        [Key]
        [Column("FilialId")]
        public int FilialId { get; set; }

        [Column("Campus")]
        public string Campus { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("CNPJ")]
        public string Cnpj { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        [Column("Endereco")]
        public string Endereco { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [DisplayName("Instituição")]
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }

        public virtual List<Curso> Cursos { get; set; }
    }
}
