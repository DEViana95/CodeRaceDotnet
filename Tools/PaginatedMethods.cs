namespace BaseApi.Tools
{
    public static class PaginatedMethods
    {
        /// <summary>
        /// Calcula o inicio da paginação.
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static int CalculateStartRow(
            int skip,
            int take
        )
        {
            return skip * take;
        }
    }
}