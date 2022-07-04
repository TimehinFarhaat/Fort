﻿using Fort.DTOs;

namespace Fort.Interfaces.Service
{
    public interface IDoctorService
    {
        public BaseResponse AddDoctor(CreateDoctorRequest Doctorrequest,int adminId);
        public DoctorResponsModel GetDoctorById(int id);
        public DoctorResponsModel GetDoctor(string email);
        public BaseResponse DeleteDoctor(int DoctorId);
        public BaseResponse UpdateDoctor(UpdateDoctorRequest request, int id);
        public DoctorsResponseModel GetDoctors();
    }
}
