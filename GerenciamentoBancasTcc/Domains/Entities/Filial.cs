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
        [Required(ErrorMessage = "É necessário preencher o nome do campus.")]
        public string Campus { get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "É necessário informar um e-mail.")]
        public string Email { get; set; }

        [Column("CNPJ")]
        [Required(ErrorMessage = "É necessário informar o CNPJ.")]
        public string Cnpj { get; set; }

        [Column("Telefone")]
        [Required(ErrorMessage = "É necessário informar um telefone.")]
        public string Telefone { get; set; }

        [Column("Endereco")]
        [DisplayName("Endereço")]
        [Required(ErrorMessage = "É necessário informar um endereço.")]
        public string Endereco { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [DisplayName("Instituição")]
        [Required(ErrorMessage = "É necessário selecionar uma instituição.")]
        public int InstituicaoId { get; set; }
        public virtual Instituicao Instituicao { get; set; }

        public virtual List<Curso> Cursos { get; set; }
    }
}
