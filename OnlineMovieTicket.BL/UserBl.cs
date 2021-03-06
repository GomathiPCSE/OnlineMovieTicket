﻿using OnlineMovieTicket.DAL;
using OnlineMovieTicket.Entity;
using System.Data;
namespace OnlineMovieTicket.BL
{
    public class UserBl
    {
        public static bool Login(string mailId, string password)
        {
            bool isOkay = UserRepository.Login(mailId, password);
            return isOkay;
        }
        public static bool Register(UserEntity user)
        {
            bool result = UserRepository.Register(user);
            return result;
        }
        public static DataTable Refreshdata()
        {
            DataTable dataTable = UserRepository.Refreshdata();
            return dataTable;
        }
        public static void RowDeleting(int id)
        {
            UserRepository.RowDeleting(id);
        }
        public static void RowUpdating(string txtMovie, int id)
        {
            UserRepository.RowUpdating(txtMovie, id);
        }
        public static void RowInserting(string movieName)
        {
            UserRepository.RowInserting(movieName);
        }
    }
}
