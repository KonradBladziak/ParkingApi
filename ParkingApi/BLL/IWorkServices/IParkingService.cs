﻿using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IWorkServices
{
    public interface IParkingService
    {
        Task<List<Parking>> GetParkingi();
        Task<Parking> GetParkingiById(int id);
        Task AddParking(Parking parking);
        Task AddParking(string nazwaParkingu, string adres, int idMiasta, int idOpiekuna);
        Task DeleteParking(Parking parking);
        Task UpdateParking(Parking parking);
        Task<ICollection<Opiekun>> AddOpiekun(int idParkingu,int idOpiekuna);
        Task<ICollection<Miejsce>> AddMiejsca(int id, int count);
    }
}
