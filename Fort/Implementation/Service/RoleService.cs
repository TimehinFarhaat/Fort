using Fort.DTOs;
using Fort.Identity;
using Fort.Interfaces.Repository;
using Fort.Interfaces.Service;

namespace Fort.Implementation.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IAdminRepository _adminRepository;

        

        public RoleService(IRoleRepository roleRepository, IAdminRepository adminRepository)
        {
            _roleRepository = roleRepository;
            _adminRepository = adminRepository;
        }



        public BaseResponse AddRole(CreateRoleRequest role)
        {
           
            
            {
                var rul = _roleRepository.GetByExpression(d => d.Name == role.Name);
                if (rul == null)
                {
                    var Rol = new Role
                    {
                        Name = role.Name,
                        CreatedOn = DateTime.Now,
                        Description = role.Description,
                        LastModifiedOn = DateTime.Now,
             
                        IsDeleted = false,

                    };
                    _roleRepository.Add(Rol);
                    return new BaseResponse
                    {
                        Message = "Successful",
                        Status = true,
                    };
                }
                return new BaseResponse
                {
                    Message = "Role already exist",
                    Status = false,
                };
            }
            
        }



        public BaseResponse DeleteRole(int roleId)
        {
            var role = _roleRepository.GetRole(roleId);
            if (role == null)
            {
                return new BaseResponse
                {
                    Message = "Not found",
                    Status = false,
                };
            }
            role.IsDeleted = true;
            role.DeletedOn = DateTime.Now;
            
            _roleRepository.Update(role);
            
            return new BaseResponse
            {
                Message = "Deleted successful",
                Status = true
            };
        }

        public RoleResponsModel GetRole(int id)
        {
            var role = _roleRepository.GetRole(id);
            if (role == null)
            {
                return new RoleResponsModel
                {
                    Message = "Not found",
                    Status = false,
                };
            }
            return new RoleResponsModel
            {
                Data = new RoleDto
                {
                    Description = role.Description,
                    Id = id,
                    Name = role.Name,
                    Roles = role.UserRoles
                },
                Message ="Successful",
                Status=true,
            };
        }

        public RoleResponseModel GetRoles()
        {
            var roles= _roleRepository.GetRoles();
            return new RoleResponseModel
            {
                Data = roles.Select(role => new RoleDto
                {
                    Description = role.Description,
                    Id = role.Id,
                    Name = role.Name,
                    Roles = role.UserRoles,
                    

                }).ToList(),
                 Message = "Successful",
                Status = true,
            };
        }

        public RoleResponseModel GetSelectedRoles(IList<int> Ids)
        {
            var roles = _roleRepository.GetSelectedRoles(Ids);
            if(roles != null)
            {
                return new RoleResponseModel
                {
                    Data = roles.Select(role => new RoleDto
                    {
                        Description = role.Description,
                        Id = role.Id,
                        Name = role.Name,
                        Roles = role.UserRoles

                    }).ToList(),
                    Message = "Successful",
                    Status = true,
                };
            }
            return new RoleResponseModel
            {
                
                Message = "roles not found",
                Status = false,
            };

        }

        public BaseResponse UpdateRole(UpdateRoleRequest role,int id)
        {
                var rol= _roleRepository.GetByExpression(c => c.Id == id);
                if(rol != null)
                {
                    rol.Name = role.Name;
                    rol.CreatedOn = DateTime.Now;
                    rol.Description = role.Description;
                    rol.LastModifiedOn = DateTime.Now;
                    
               
                    _roleRepository.Update(rol);
                    return new BaseResponse
                    {
                        Message = "Successful",
                        Status = true,
                    };
                }
              
                return new BaseResponse
                {
                    Message = "unSuccessful",
                    Status = false,
                };
           
        }
    }
}
