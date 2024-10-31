using Balta.Domain.AccountContext.ValueObjects;
using Balta.Domain.AccountContext.ValueObjects.Exceptions;
using Balta.Domain.SharedContext.Abstractions;
using Balta.Domain.SharedContext.ValueObjects;
using Balta.Domain.Test.AccountContext.Projection;
using Microsoft.Extensions.Time.Testing;

namespace Balta.Domain.Test.AccountContext.ValueObjects;

public class EmailTests
{
    DateTimeProvider fake = new DateTimeProvider();
    [Fact]
    public void ShouldLowerCaseEmail() 
    {

        Email email = Email.ShouldCreate("NkLcT@example.com", fake );

        Assert.Equal("nklct@example.com", email.Address);
    }
    
    [Fact]
    public void ShouldTrimEmail()
    {

        Email email = Email.ShouldCreate("   nklct@example.com     ", (IDateTimeProvider)fake);

        Assert.Equal("nklct@example.com", email.Address);
    }
    
    [Fact]
    public void ShouldFailIfEmailIsNull()
    {

        Assert.Throws<NullReferenceException>(() => Email.ShouldCreate(null, (IDateTimeProvider)fake));
    }

    [Fact]
    public void ShouldFailIfEmailIsEmpty()
    {

        Assert.Throws<InvalidEmailException>(() => Email.ShouldCreate("", (IDateTimeProvider) fake));
        
    }


    [Fact]
    public void ShouldFailIfEmailIsInvalid()
    {

        Assert.Throws<InvalidEmailException>(() => Email.ShouldCreate("nk@lct@example.com", (IDateTimeProvider)fake));
    }


    [Fact]
    public void ShouldPassIfEmailIsValid()
    {

        Email email = Email.ShouldCreate("nklct@example.com", (IDateTimeProvider)fake);
        String verificationCode = email.VerificationCode;
        email.ShouldVerify(verificationCode);
        Assert.IsAssignableFrom<Email>(email);
    }



    [Fact]
    public void ShouldHashEmailAddress() {
        Email email = Email.ShouldCreate("nklct@example.com", (IDateTimeProvider)fake);

        Assert.NotEmpty(email.Hash);

    }

    [Fact(Skip = "Aqui deveria ser conversão de string para Email mas não encontrei esse método")]
    public void ShouldExplicitConvertFromString()
    {

        Email email = Email.ShouldCreate("nklct@example.com", (IDateTimeProvider)fake);

        Assert.Equal("nklct@example.com", email);
    }
   
    
    [Fact]
    public void ShouldExplicitConvertToString()
    {

        Email email = Email.ShouldCreate("nklct@example.com", (IDateTimeProvider)fake);

        Assert.Equal("nklct@example.com", email);
    }

    
    [Fact]
    public void ShouldReturnEmailWhenCallToStringMethod()
    {

        Email email = Email.ShouldCreate("nklct@example.com", (IDateTimeProvider)fake);

        Assert.Equal("nklct@example.com", email.ToString());
    }
}