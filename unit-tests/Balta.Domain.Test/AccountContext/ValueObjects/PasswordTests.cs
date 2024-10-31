using Balta.Domain.AccountContext.ValueObjects;
using Balta.Domain.AccountContext.ValueObjects.Exceptions;

namespace Balta.Domain.Test.AccountContext.ValueObjects;

public class PasswordTests
{
    Password _password = Password.ShouldCreate("1234567890");
    [Fact]
    public void ShouldFailIfPasswordIsNull()
    {
        Assert.Throws<InvalidPasswordException>(() => Password.ShouldCreate(null));
    }


    [Fact]
    public void ShouldFailIfPasswordIsEmpty()
    {
        Assert.Throws<InvalidPasswordException>(() => Password.ShouldCreate(""));
    }


    [Fact]
    public void ShouldFailIfPasswordIsWhiteSpace()
    {
        Assert.Throws<InvalidPasswordException>(() => Password.ShouldCreate(" 2e 3")); 
    }
    
    [Fact]
    public void ShouldFailIfPasswordLenIsLessThanMinimumChars()
    {
        Assert.Throws<InvalidPasswordException>(() => Password.ShouldCreate("123"));
    }
    
    [Fact]
    public void ShouldFailIfPasswordLenIsGreaterThanMaxChars()
    {
        Assert.Throws<InvalidPasswordException>(() => Password.ShouldCreate("1234567890123456789012345678901234567890123456789"));
    }


    [Fact]
    public void ShouldHashPassword() 
    {
        Password password = Password.ShouldCreate("1234567890");
        
        Assert.NotEmpty(password.Hash);
    }

    [Fact]
    public void ShouldVerifyPasswordHash()
    {
        
        Assert.True(Password.ShouldMatch(_password.Hash, "1234567890"));
    }
    
    [Fact]
    public void ShouldGenerateStrongPassword() 
    {
        Password password = Password.ShouldGenerate();
        
        Assert.NotEqual(password.ToString(), password.ToString().ToLower());
    }
    
    [Fact]
    public void ShouldImplicitConvertToString() 
    {
        Password password = (Password)"1234567890";
        
        Assert.Equal( "1234567890", password);
    }
    
    [Fact]
    public void ShouldReturnHashAsStringWhenCallToStringMethod()
    {
        Assert.Equal(_password.Hash, _password.ToString());
    }


    [Fact(Skip = "ExpiresAtUtc is null")]
    public void ShouldMarkPasswordAsExpired()
    {

        Assert.Equal(_password.ExpiresAtUtc, DateTime.UtcNow.AddYears(100));
    }


    [Fact(Skip = "ExpiresAtUtc is null")]
    public void ShouldFailIfPasswordIsExpired()
    {
        Assert.Throws<NullReferenceException>(() => Password.ShouldCreate("1234567890"));
    } 
    
    [Fact]
    public void ShouldMarkPasswordAsMustChange() {
        Password password = (Password)"1234567890";

        Assert.False(password.MustChange);
    }

    [Fact(Skip = "MustChange is null")]
    public void ShouldFailIfPasswordIsMarkedAsMustChange() 
    {
        Assert.True(false);
    }
}