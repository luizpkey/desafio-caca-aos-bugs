using Balta.Domain.AccountContext.ValueObjects;
using Balta.Domain.Test.AccountContext.Projection;

namespace Balta.Domain.Test.AccountContext.ValueObjects;

public class VerificationCodeTest
{
    DateTimeProvider fake = new DateTimeProvider();
    [Fact]
    public void ShouldGenerateVerificationCode(){

        VerificationCode verificationCode = VerificationCode.ShouldCreate(fake);

        Assert.IsAssignableFrom<VerificationCode>(verificationCode);
    }

    [Fact]
    public void ShouldGenerateExpiresAtInFuture() {

        VerificationCode verificationCode = VerificationCode.ShouldCreate(fake);

        Assert.IsAssignableFrom<DateTime>(verificationCode.ExpiresAtUtc);
    }

    [Fact(Skip = "Not implemented yet")]
    public void ShouldGenerateVerifiedAtAsNull() => Assert.Fail();

    [Fact(Skip = "Not implemented yet")]
    public void ShouldBeInactiveWhenCreated() => Assert.Fail();

    [Fact(Skip = "Not implemented yet")]
    public void ShouldFailIfExpired() => Assert.Fail();

    [Fact(Skip = "Not implemented yet")]
    public void ShouldFailIfCodeIsInvalid() => Assert.Fail();

    [Fact(Skip = "Not implemented yet")]
    public void ShouldFailIfCodeIsLessThanSixChars() => Assert.Fail();

    [Fact(Skip = "Not implemented yet")]
    public void ShouldFailIfCodeIsGreaterThanSixChars() => Assert.Fail();

    [Fact(Skip = "Not implemented yet")]
    public void ShouldFailIfIsNotActive() => Assert.Fail();

    [Fact(Skip = "Not implemented yet")]
    public void ShouldFailIfIsAlreadyVerified() => Assert.Fail();

    [Fact(Skip = "IsActive is ReadOnly")]
    public void ShouldFailIfIsVerificationCodeDoesNotMatch()
    {
        VerificationCode verificationCode = VerificationCode.ShouldCreate(fake);
        verificationCode.ShouldVerify("123456");

        Assert.Throws<NullReferenceException>(() => verificationCode.ShouldVerify("654321"));
    }

    [Fact(Skip = "IsActive is ReadOnly")]
    public void ShouldVerify()
    {
        VerificationCode verificationCode = VerificationCode.ShouldCreate(fake);
        verificationCode.ShouldVerify("123456");
        verificationCode.ShouldVerify("123456");
        Assert.True(true);
    }
}