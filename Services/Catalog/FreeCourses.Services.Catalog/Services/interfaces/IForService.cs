﻿using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.For;

namespace FreeCourses.Services.Catalog.Services.interfaces
{
    public interface IForService
    {
        Task<Response<ForDto>> CreateAsync(ForDto category);
        Task<Response<List<ForDto>>> GetAllAsync();
        Task<Response<ForDto>> GetByIdAsync(string id);
        Task<Response<NoConetent>> DeleteAsync(string id);

    }
}
