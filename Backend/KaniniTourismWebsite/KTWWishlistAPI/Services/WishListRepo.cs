using KTWWishlistAPI.Interfaces;
using KTWWishlistAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace KTWWishlistAPI.Services
{
    public class WishListRepo : IRepo
    {
        private readonly SqlConnection _conn;

        public WishListRepo(SqlConnection conn)
        {
            _conn = conn;
        }
        public async Task<WishList?> Add(WishList wishList)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("proc_AddWishlist", _conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@userId", wishList.UserId);
                sqlCommand.Parameters.AddWithValue("@packageId", wishList.PackageId);
                SqlParameter parameter = new SqlParameter("@WLId", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(parameter);
               
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
                _conn.Open();
                var result = await sqlCommand.ExecuteNonQueryAsync();
                if (result > 0)
                {
                    wishList.WishListId = Convert.ToInt32(parameter.Value.ToString());
                    return wishList;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return null;

        }


        public async Task<int> Delete(int id)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("proc_DeleteWishList", _conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@WishListid",id);
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
                _conn.Open();
               return await sqlCommand.ExecuteNonQueryAsync();
          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return 0;
        }

        public async Task<ICollection<WishList>?> GetAll()
        {
            try
            {
                List<WishList> wishLists = new List<WishList>();
                SqlCommand cmd = new SqlCommand("proc_GetAllWishList", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (_conn.State != ConnectionState.Open)
                    _conn.Close();
                _conn.Open();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    WishList wishList = new WishList();
                    wishList.WishListId = Convert.ToInt32(reader["wishListId"].ToString());
                    wishList.UserId = Convert.ToInt32(reader["userId"].ToString());
                    wishList.PackageId = Convert.ToInt32(reader["packageId"].ToString());

                    wishLists.Add(wishList);
                }

                return wishLists;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
            finally { _conn.Close(); }
            return null;
        }
    }
}
