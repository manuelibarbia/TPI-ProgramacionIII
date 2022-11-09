using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TPIntegradorProgIII.Data.Repository.Interfaces;

namespace TPIntegradorProgIII.Data.Repository
{
    public interface IMeetRepository : ITPRepository
    {
    }
}
