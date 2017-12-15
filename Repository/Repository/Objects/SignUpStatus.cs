namespace Repository.BLL
{
    //
    // Summary:
    //     Possible results from a sign in attempt
    public enum SignUpStatus
    {
        //
        // Summary:
        //     Sign in was successful
        Success = 0,
        //
        // Summary:
        //     User is exists
        UserExist = 1,
        //
        // Summary:
        //     Sign in failed
        Failure = 3
    }
}
