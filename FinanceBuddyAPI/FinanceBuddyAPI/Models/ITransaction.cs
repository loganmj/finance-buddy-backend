namespace FinanceBuddyAPI.Models
{
    /// <summary>
    /// An interface for a Transaction object.
    /// </summary>
    public interface ITransaction
    {
        #region Properties

        /// <summary>
        /// Primary key ID of the transaction.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// An identier name of the transaction.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The amount that the transaction was for.
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        /// The date that the transaction took place.
        /// </summary>
        DateTime TransactionDate { get; set; }

        #endregion
    }
}