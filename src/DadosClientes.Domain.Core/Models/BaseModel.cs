using System;
using System.ComponentModel.DataAnnotations;

namespace DadosClientes.Domain.Core.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        public bool Ativo { get; set; }

        private DateTime? _createAt;
        public DateTime? CreateAt {
            get { return _createAt == null ? (_createAt = DateTime.UtcNow) : _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }
        public DateTime? UpdateAt { get; set; }
    }
}