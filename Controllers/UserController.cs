using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OMSDAdmin.ViewModels;
using OMSDAdmin.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Province = OMSDAdmin.ViewModels.Province;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using System.Diagnostics;

namespace OMSDAdmin.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private OMSDStagingSTI_CustomContext _OMSDContext;
        private IConfiguration _configuration;
        private IList<UserViewModel> userModelViewList;
        public UserController(OMSDStagingSTI_CustomContext aOMSDContext, IConfiguration aConfiguration)
        {
            this._OMSDContext = aOMSDContext;
            this._configuration = aConfiguration;

        }

        [HttpPost("[action]")]
        public UserViewModel Authenticate([FromBody]UserViewModel aUser)
        {
            var user = AuthenticateUser(aUser.Email, aUser.Password);

            if (user == null) return new UserViewModel
            {
                UserId = 0,
                Email = "",
                UserFirstName = "",
                UserLastName = "",
                Token = "",
                Password = "",
                Message = "email or passowrd is not correct",
                Address = "",
                Province = "",
                City = "",
                PostCode = "",
                PhoneNumber = "",
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<String>("SecretAPIKey"));
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.ClinicUserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenString = tokenHandler.WriteToken(token);

            return new UserViewModel
            {
                UserId = user.ClinicUserId,
                Email = user.Email,
                UserFirstName = user.Firstname,
                UserLastName = user.Lastname,
                Token = tokenString,
                Password = "",
                Message = "Successfully Login",
                Address = "",
                Province = "",
                City = "",
                PostCode = "",
                PhoneNumber = "",
            };

        }
        // GET: api/<controller>
        [HttpGet("[action]")]
        [Authorize]
        public IEnumerable<UserViewModel> GetUsers()
        {
            var currentUser = HttpContext.User;
            IList<UserViewModel> userList = new List<UserViewModel>();
            //if (currentUser.HasClaim(c => c.Type == ClaimTypes.PrimarySid))
            if (true)
            {
                var clinicUserId = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value;
                var authUser = _OMSDContext.ClinicUser.Find(Int32.Parse(clinicUserId));
                //if (authUser != null)
                if (true)
                {
                    var authUserRole = authUser.ClinicUserType;
                    //if (authUserRole == 3)
                    if (true)
                    {
                        SetUserModelViewList(_OMSDContext.ClinicUser.ToList());
                    }
                    else
                    {
                        var userViewModelList = new List<UserViewModel>();
                        userViewModelList.Add(new UserViewModel
                        {
                            UserId = 0,
                            Email = "",
                            UserFirstName = "",
                            UserLastName = "",
                            Token = "",
                            Password = "",
                            Message = "Not Admin",
                            Address = "",
                            Province = "",
                            City = "",
                            PostCode = "",
                            PhoneNumber = ""
                        });
                        return userViewModelList;
                    }
                }
            }
            else
            {
                var userViewModelList = new List<UserViewModel>();
                userViewModelList.Add(new UserViewModel
                {
                    UserId = 0,
                    Email = "",
                    UserFirstName = "",
                    UserLastName = "",
                    Token = "",
                    Password = "",
                    Message = "Token expired",
                    Address = "",
                    Province = "",
                    City = "",
                    PostCode = "",
                    PhoneNumber = ""
                });
                return userViewModelList;
            }
            return GetUserModelViewList();
        }

        // GET api/<controller>/5
        [HttpGet("[action]/{id}")]
        [Authorize]
        public UserViewModel GetUser(int id)
        {
            var aAuthUser = VerifyUser(HttpContext.User);

            ClinicUser aClinicUser = null;
            //if(aAuthUser.ClinicUserType == UserType.AdminUser.Id)
            if (true)
            {
                aClinicUser = _OMSDContext.ClinicUser.Find(id);
            }

            if(aClinicUser != null)
            {
                return new UserViewModel
                {
                    UserId = aClinicUser.ClinicUserId,
                    Email = aClinicUser.Email,
                    UserFirstName = aClinicUser.Firstname,
                    UserLastName = aClinicUser.Lastname,
                    Token = "",
                    Password = "",
                    Message = "find user",
                    Address = aClinicUser.Address1,
                    Province = Province.Find(aClinicUser.Province).Name,
                    City = aClinicUser.City,
                    PostCode = aClinicUser.PostalCode,
                    PhoneNumber = aClinicUser.PhoneNumber,
                };
            }
            else
            {
                return new UserViewModel
                {
                    UserId = -1,
                    Email = "",
                    UserFirstName = "",
                    UserLastName = "",
                    Token = "",
                    Password = "",
                    Message = "Failed to Find this user",
                    Address = "",
                    Province = "",
                    City = "",
                    PostCode = "",
                    PhoneNumber = "",
                };
            }

        }

        // POST api/<controller>
/*        [HttpPost("[action]")]
        [Authorize]
        public IEnumerable<UserViewModel> SearchUsers([FromBody]string keyWord)
        {
            //Search user name, 
            var users = _OMSDContext.ClinicUser.Where(x =>
            x.Firstname.Contains(keyWord) ||
            x.Lastname.Contains(keyWord) ||
            x.Email.Contains(keyWord) ||
            x.Address1.Contains(keyWord) || x.City.Contains(keyWord) || x.PostalCode.Contains(keyWord) || x.PhoneNumber.Contains(keyWord)
            );

            SetUserModelViewList(users.ToList());
            return GetUserModelViewList();
        }*/

        // POST api/<controller>
        [HttpPost("[action]")]
        [Authorize]
        public UserViewModel Register([FromBody]UserViewModel aNewUser)
        {
            if (string.IsNullOrWhiteSpace(aNewUser.Password))
            {
                return new UserViewModel
                {
                    UserId = 0,
                    Email = "",
                    UserFirstName = "",
                    UserLastName = "",
                    Token = "",
                    Password = "",
                    Message = "passowrd is invalid",
                    Address = "",
                    Province = "",
                    City = "",
                    PostCode = "",
                    PhoneNumber = "",
                };
            }

            if(_OMSDContext.ClinicUser.Any(x => x.Email == aNewUser.Email))
            {
                return new UserViewModel
                {
                    UserId = 0,
                    Email = "",
                    UserFirstName = "",
                    UserLastName = "",
                    Token = "",
                    Password = "",
                    Message = "email is already register",
                    Address = "",
                    Province ="",
                    City = "",
                    PostCode = "",
                    PhoneNumber = "",
                };
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(aNewUser.Password, out passwordHash, out passwordSalt);
            var aUser = CreateNewUser(aNewUser, passwordHash, passwordSalt);

/*            _OMSDContext.ClinicUser.Add(aUser);
            _OMSDContext.SaveChanges();*/

            return new UserViewModel
            {
                UserId = aUser.ClinicUserId,
                Email = aUser.Email,
                UserFirstName = aUser.Firstname,
                UserLastName = aUser.Lastname,
                Token = "",
                Password = "",
                Message = "email is successfully register",
                Address = "",
                Province="",
                City = "",
                PostCode = "",
                PhoneNumber = "",
            };

        }

        // PUT api/<controller>/5
        [HttpPut("[action]")]
        [Authorize]
        public UserViewModel UpdateUser([FromBody]UserViewModel aUser)
        {
            var aAuthUser = VerifyUser(HttpContext.User);

            if (aAuthUser.ClinicUserId == aUser.UserId)
            {
                var aClinicUser = _OMSDContext.ClinicUser.Find(aUser.UserId);
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(aUser.Password, out passwordHash, out passwordSalt);
                aClinicUser.Email = aUser.Email;
                aClinicUser.Firstname = aUser.UserFirstName;
                aClinicUser.Lastname = aUser.UserLastName;
                aClinicUser.Password = Convert.ToBase64String(passwordHash);
                aClinicUser.Pin = Convert.ToBase64String(passwordSalt);
                aClinicUser.Address1 = aUser.Address;
                aClinicUser.City = aUser.City;
                aClinicUser.Province = Province.Find(aUser.Province).Id;
                aClinicUser.PhoneNumber = aUser.PhoneNumber;
                aClinicUser.PostalCode = aUser.PostCode;
                aClinicUser.ModifiedDate = DateTime.Now;

                using (_OMSDContext)
                {
/*                    _OMSDContext.ClinicUser.Update(aClinicUser);
                    _OMSDContext.SaveChanges();*/
                }

            }
            return aUser;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void DeleteUser(int id)
        {
            var aAuthUser = VerifyUser(HttpContext.User);
            if(aAuthUser != null)
            {
                using (_OMSDContext)
                {
                    //_OMSDContext.ClinicUser.Remove(_OMSDContext.ClinicUser.Find(id));
                    //_OMSDContext.SaveChanges();
                }
            }
        }

        private ClinicUser AuthenticateUser(string aUserEmail, string aPassword)
        {
            if(string.IsNullOrEmpty(aUserEmail) || string.IsNullOrEmpty(aPassword))
            {
                return null;
            }

            var user = _OMSDContext.ClinicUser.Where(x => x.Email == aUserEmail).FirstOrDefault();

            if(user == null)
            {
                return null;
            }

            var ppp = Encoding.Unicode.GetBytes(user.Password);

            if(VerifyPassword(aPassword, Convert.FromBase64String(user.Password), Convert.FromBase64String(user.Pin)) == false){
                return null;
            }

            return user;
        }

        private Boolean VerifyPassword(string password, Byte[] passwordHash, Byte[] passwordSalt)
        {
            if (passwordHash.Length != 64) throw new ArgumentException("Invalid length of passwordHash");
            if (passwordSalt.Length != 128) throw new ArgumentException("Invalid length of passwordSalt");

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(password));
                for(int i=0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new Exception("password can not be null");
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("password can not be empty or whitespace");

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(password));
            }
        }
        
        private ClinicUser CreateNewUser(UserViewModel aUserViewModel, byte[] passwordHash, byte[] passwordSalt)
        {
            ClinicUser aUser = new ClinicUser();
            aUser.Editstate = 0;
            aUser.Sublistingid = 0;
            aUser.Datecreated = DateTime.Now;
            aUser.Lastname = aUserViewModel.UserLastName;
            aUser.City = aUserViewModel.City;
            aUser.ClinicUserType = 3;
            aUser.Address1 = aUserViewModel.Address;
            aUser.Status = 4;
            aUser.Province = 1;
            aUser.Email = aUserViewModel.Email;
            aUser.PostalCode = aUserViewModel.PostCode;
            aUser.Address2 = "";
            aUser.Pin = Convert.ToBase64String(passwordSalt);
            aUser.Firstname = aUserViewModel.UserFirstName;
            aUser.Password = Convert.ToBase64String(passwordHash);
            aUser.AgreeToTerms = 0;
            aUser.PhoneNumber = aUserViewModel.PhoneNumber;
            aUser.Fax = "";
            aUser.ModifiedDate = DateTime.Now;
            aUser.CreatedDate = DateTime.Now;
            aUser.DateActivated = DateTime.Now;
            aUser.DiabetesId = null;
            aUser.PhysicianLastNameforCsn = "";
            aUser.AdminInfo = "";

            return aUser;
        }

        private void SetUserModelViewList(IList<ClinicUser> aUserList)
        {
            userModelViewList = new List<UserViewModel>();
            var provinceList = _OMSDContext.Province;
            foreach(var aUser in aUserList)
            {
                var aUserModelView = new UserViewModel();
                aUserModelView.UserId = aUser.ClinicUserId;
                aUserModelView.Email = aUser.Email;
                aUserModelView.UserFirstName = aUser.Firstname;
                aUserModelView.UserLastName = aUser.Lastname;
                aUserModelView.Password = "";
                aUserModelView.Token = "";
                aUserModelView.Message = "";
                aUserModelView.Address = aUser.Address1;
                aUserModelView.City = aUser.City;
                aUserModelView.Province = "Ontario";
                if (aUser.Province != 1)
                {
                    aUserModelView.Province = provinceList.Where(x => x.ProvinceId == aUser.Province).FirstOrDefault().Name;
                }                
                aUserModelView.PostCode = aUser.PostalCode;
                aUserModelView.PhoneNumber = aUser.PhoneNumber;

                userModelViewList.Add(aUserModelView);
            }
        }

        private IList<UserViewModel> GetUserModelViewList()
        {
            return userModelViewList;
        }

        private ClinicUser VerifyUser(ClaimsPrincipal aCurrentSystemUser)
        {
            ClinicUser aClinicUser = null;
            if(aCurrentSystemUser.HasClaim(c => c.Type == ClaimTypes.PrimarySid))
            {
                aClinicUser = _OMSDContext.ClinicUser.Find(Int32.Parse(
                    aCurrentSystemUser.
                    Claims.
                    FirstOrDefault(c => 
                    c.Type == ClaimTypes.PrimarySid).Value
                    ));
            }

            return aClinicUser;
        }
    }
}
