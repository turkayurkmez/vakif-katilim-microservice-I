﻿namespace Catalog.Domain
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? Stock { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // TODO 1: Entity yapısını tanımla!

    }
}
