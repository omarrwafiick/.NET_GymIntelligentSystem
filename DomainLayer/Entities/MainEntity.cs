
using DomainLayer.Contracts;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public abstract class MainEntity : IMainEntity
    {
        [Key]
        public Guid Id { get; }
    }
}
