using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.ApiResponse;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private DatabaseContext _context { get; }
        private IConfiguration _config { get; }

        public AuthService(DatabaseContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }
        

        // Kullanici kaydi yapar.
        public async Task<ServiceResponse<string>> KayıtOl(Kullanici kullanici, string sifre)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            if (await KullaniciMevcut(kullanici.KullaniciAdi))
            {
                response.Basari = false;
                response.Mesaj = "Kullanici Mevcut!";
                return response;
            }

            OlusturPasswordHash(sifre, out byte[] passwordHash, out byte[] passwordSalt);
            kullanici.PasswordHash = passwordHash;
            kullanici.PasswordSalt = passwordSalt;

            await _context.Kullanicilar.AddAsync(kullanici);
            await _context.SaveChangesAsync();

            response.data = "Kullanici Kaydi Tamamlandi";

            return response;
        }


        // Kullanici Girisi yapar. Giris basarili bir sekilde yapilirsa, ilgili kullaniciya özel JWT gösterilir.
        public async Task<ServiceResponse<string>> GirisYap(string kullaniciAdi, string sifre)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            Kullanici kullanici = await _context.Kullanicilar.FirstOrDefaultAsync(k => k.KullaniciAdi.ToLower().Equals(kullaniciAdi.ToLower()));

            if (kullanici == null)
            {
                response.Basari = false;
                response.Mesaj = "Kullanici Bulunamadi!";
            }
            else if (!DogrulaPasswordHash(sifre, kullanici.PasswordHash, kullanici.PasswordSalt))
            {
                response.Basari = false;
                response.Mesaj = "Yanlis Sifre!";
            }
            else
            {
                response.data = OlusturToken(kullanici);
            }
            return response;
        }


        // Kayit olmak isteyen kullanicinin mevcut olup olmadigini gösteren yardimci metot.
        public async Task<bool> KullaniciMevcut(string kullaniciAdi)
        {
            if (await _context.Kullanicilar.AnyAsync(k => k.KullaniciAdi.ToLower() == kullaniciAdi.ToLower()))
            {
                return true;
            }
            return false;
        }


        //Verilen sifreye göre passwordHash ve passwordSalt degerleri üretilir
        private void OlusturPasswordHash(string sifre, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(sifre));
            }
        }

        //Ilgili passwordHash kullanicisi dogrulanir
        private bool DogrulaPasswordHash(string sifre, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var hashDegeri = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(sifre));

                for (var i = 0; i < hashDegeri.Length; i++)
                {
                    if (hashDegeri[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }


        // Kullaniciya özel bir Jason Web Token yaratir ve döner
        private string OlusturToken(Kullanici kullanici)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier , kullanici.Id.ToString()),
                new Claim(ClaimTypes.Name , kullanici.KullaniciAdi),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value)
            );

            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}