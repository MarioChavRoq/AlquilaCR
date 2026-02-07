using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UsuariosDAL : DALGenerico<Usuario>, IUsuariosDAL
    {
        private AlquilaCrContext _context;
        public UsuariosDAL(AlquilaCrContext context) : base(context)
        {
            _context = context;
        }
        public List<Usuario> GetUsuarios()
        {
            string query = "sp_GetUsuarios";

            var result = _context.Usuarios.FromSqlRaw(query);

            return result.ToList();
        }

        public bool CreateUsuario(Usuario entity)
        {
            try
            {
                string sql = "EXEC [dbo].[sp_CreateUsuario] @Nombre,@Apellidos,@Email,@PasswordHash,@Telefono,@DescripcionPerfil,@ImagenPerfilUrl";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Nombre
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Apellidos",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Apellidos
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Email",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Email
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@PasswordHash",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.PasswordHash
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Telefono",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Telefono
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@DescripcionPerfil",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.DescripcionPerfil
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@ImagenPerfilUrl",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.ImagenPerfilUrl
                    }
                };

                _context
                    .Database
                    .ExecuteSqlRaw(sql, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateUsuario(Usuario entity)
        {
            try
            {
                string sql = "EXEC [dbo].[sp_UpdateUsuario] @UsuarioId,@Nombre,@Apellidos,@Email,@PasswordHash,@Telefono,@DescripcionPerfil,@ImagenPerfilUrl";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@UsuarioId",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.UsuarioId
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Nombre
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Apellidos",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Apellidos
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Email",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Email
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@PasswordHash",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.PasswordHash
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@Telefono",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Telefono
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@DescripcionPerfil",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.DescripcionPerfil
                    },

                    new SqlParameter()
                    {
                        ParameterName = "@ImagenPerfilUrl",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.ImagenPerfilUrl
                    }
                };

                _context
                    .Database
                    .ExecuteSqlRaw(sql, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteUsuario (int UsuarioId)
        {
            try
            {
                string sql = "EXEC [dbo].[sp_UpdateUsuario] @UsuarioId";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@UsuarioId",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = UsuarioId
                    }
                };

                _context
                    .Database
                    .ExecuteSqlRaw(sql, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        
    }    
}
