using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PerMS;
using PerMS.DBContext;

public class AuthService
{ 
    private readonly string _jwtSecret;
    private readonly PerMSContext _context;

    public AuthService(string jwtSecret, PerMSContext context)
    {
        _jwtSecret = jwtSecret;
        _context = context;
    }


    public string GenerateJwtToken(string userId, string userName, string FullName, string role)
    {
        int userIDD = Convert.ToInt32(userId);
        //User Claim
        var EmployeeID = _context.Users
                           .Where(u => u.Id == userIDD)
                           .Select(u => new
                           {
                           User_EmployeeId = u.User_EmployeeId
                           }).FirstOrDefault();

        int employeeID = EmployeeID?.User_EmployeeId ?? 0; // or any default value
        int roleId = Convert.ToInt32(role);
        var roleName = _context.Roles.FindAsync(roleId);
        string ? RoleName= roleName.ToString();
        string UserID = Convert.ToString(userId);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, UserID),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, RoleName)
            }),
            Expires = DateTime.UtcNow.AddMinutes(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
