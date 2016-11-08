﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.Services.Implements
{
    public class TacNghiepRepository : DbExecute, ITacNghiepRepository
    {
        public TacNghiepRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(TacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.TacNghieps.Create();

                    add.NgayHetHan = entity.NgayHetHan;
                    add.NgayHoanThanh = entity.NgayHoanThanh;
                    add.NoiDung = entity.NoiDung;
                    add.NoiDungTraoDoi = entity.NoiDungTraoDoi;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(TacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.TacNghieps.Create();

                    add.NgayHetHan = entity.NgayHetHan;
                    add.NgayHoanThanh = entity.NgayHoanThanh;
                    add.NoiDung = entity.NoiDung;
                    add.NoiDungTraoDoi = entity.NoiDungTraoDoi;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<TacNghiepResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    TacNghiep add;
                    foreach (var entity in entities)
                    {
                        add = context.TacNghieps.Create();

                        add.NgayHetHan = entity.NgayHetHan;
                        add.NgayHoanThanh = entity.NgayHoanThanh;
                        add.NoiDung = entity.NoiDung;
                        add.NoiDungTraoDoi = entity.NoiDungTraoDoi;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<TacNghiepResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    TacNghiep add;
                    foreach (var entity in entities)
                    {
                        add = context.TacNghieps.Create();

                        add.NgayHetHan = entity.NgayHetHan;
                        add.NgayHoanThanh = entity.NgayHoanThanh;
                        add.NoiDung = entity.NoiDung;
                        add.NoiDungTraoDoi = entity.NoiDungTraoDoi;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(TacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(TacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult DeleteBy(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghieps.Single(x => x.Id == id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteByAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghieps.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;

                    context.Entry(cv).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<TacNghiepResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghieps
                        where item.IsDeleted == false
                        select new TacNghiepResult
                        {
                            Id = item.Id,
                            NgayHetHan = item.NgayHetHan,
                            NgayHoanThanh = item.NgayHoanThanh,
                            NoiDung = item.NoiDung,
                            NoiDungTraoDoi = item.NoiDungTraoDoi,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToList();
                }
            });
        }

        public async Task<IEnumerable<TacNghiepResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TacNghieps
                        where item.IsDeleted == false
                        select new TacNghiepResult
                        {
                            Id = item.Id,
                            NgayHetHan = item.NgayHetHan,
                            NgayHoanThanh = item.NgayHoanThanh,
                            NoiDung = item.NoiDung,
                            NoiDungTraoDoi = item.NoiDungTraoDoi,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToListAsync();
                }
            });
        }

        public TacNghiepResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghieps
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new TacNghiepResult
                        {
                            Id = item.Id,
                            NgayHetHan = item.NgayHetHan,
                            NgayHoanThanh = item.NgayHoanThanh,
                            NoiDung = item.NoiDung,
                            NoiDungTraoDoi = item.NoiDungTraoDoi,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).Single();
                }
            });
        }

        public async Task<TacNghiepResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TacNghieps
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new TacNghiepResult
                        {
                            Id = item.Id,
                            NgayHetHan = item.NgayHetHan,
                            NgayHoanThanh = item.NgayHoanThanh,
                            NoiDung = item.NoiDung,
                            NoiDungTraoDoi = item.NoiDungTraoDoi,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).SingleAsync();
                }
            });
        }

        public SaveResult Update(TacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.NgayHetHan = entity.NgayHetHan;
                    update.NgayHoanThanh = entity.NgayHoanThanh;
                    update.NoiDung = entity.NoiDung;
                    update.NoiDungTraoDoi = entity.NoiDungTraoDoi;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(TacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.NgayHetHan = entity.NgayHetHan;
                    update.NgayHoanThanh = entity.NgayHoanThanh;
                    update.NoiDung = entity.NoiDung;
                    update.NoiDungTraoDoi = entity.NoiDungTraoDoi;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }
    }
}