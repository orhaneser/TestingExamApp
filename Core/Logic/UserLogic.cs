using Core.Helper;
using Examp.Database;
using Examp.Dto;
using LocationApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic
{
   public class UserLogic
    {
        public ResultHelper AddUser(UserDto userDto)
        {
            try
            {
                User item = new User();
                item.UserID = userDto.UserID;
                item.Mail = userDto.Mail;
                item.Password = userDto.Password;
                item.Role = userDto.Role;

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<User>().Insert(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.UserID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, 0, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper SetUser(UserDto userDto)
        {
            try
            {
                User item = new User();
                item.UserID = userDto.UserID;
                item.Mail = userDto.Mail;
                item.Password = userDto.Password;
                item.Role = userDto.Role;
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<User>().Update(item);
                    unitOfWork.saveChanges();
                    return new ResultHelper(true, item.UserID, ResultHelper.SuccessMessage);
                }
            }
            catch (Exception ex)
            {
                return new ResultHelper(false, userDto.UserID, ResultHelper.UnSuccessMessage);
            }
        }
        public ResultHelper DelUser(int UserID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    var selected = unitofWork.GetRepository<User>().GetById(x => x.UserID == UserID);
                    unitofWork.GetRepository<User>().Delete(selected);
                    unitofWork.saveChanges();
                    return new ResultHelper(true, selected.UserID, ResultHelper.UnSuccessMessage + "\n" + ResultHelper.DontDeleted);
                }
            }
            catch (Exception)
            {
                return new ResultHelper(false, UserID, ResultHelper.UnSuccessMessage);

            }
        }
        public UserDto GetUser(int UserID)
        {
            try
            {
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    User item = new User();
                    item = unitofWork.GetRepository<User>().GetById(x => x.UserID == UserID);
                    UserDto userDto = new UserDto();
                    userDto.UserID = item.UserID;
                    userDto.Mail = item.Mail;
                    userDto.Password = item.Password;
                    userDto.Role = item.Role.Value;
                    return userDto;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<UserDto> GetAllUser()
        {
            try
            {
                List<UserDto> list = new List<UserDto>();
                using (UnitOfWork unitofWork = new UnitOfWork())
                {
                    List<User> collection = unitofWork.GetRepository<User>().Select(null, null).ToList();
                    foreach (var item in collection)
                    {
                        UserDto userDto = new UserDto();
                        userDto.UserID = item.UserID;
                        userDto.Mail = item.Mail;
                        userDto.Password = item.Password;
                        userDto.Role = item.Role.Value;
                        list.Add(userDto);

                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                return new List<UserDto>();
            }
        }



    }
}
