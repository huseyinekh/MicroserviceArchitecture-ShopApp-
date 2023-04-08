﻿using FreeCourses.Services.Catalog.Dtos.Category;
using FreeCourses.Services.Catalog.Dtos.Feauture;

namespace FreeCourses.Services.Catalog.Dtos.Course
{
    public class CourseUpdateDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public string? Picture { get; set; }


        public decimal Price { get; set; }

        public FeatureDto? Feature { get; set; }

        public CategoryDto? Category { get; set; }

        public string? CategoryId { get; set; }
    }
}