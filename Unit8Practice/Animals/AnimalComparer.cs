namespace Unit8Practice.Animals
{
    internal class AnimalComparer : IEqualityComparer<Animal>
    {

        public bool Equals(Animal x, Animal y)
        {
            if (x == null || y == null)
                return false;

            return x.Equals(y);
        }

        public int GetHashCode(Animal obj)
        {
            if (obj == null)
                return 0;

            return HashCode.Combine(obj.GetAge(), obj.GetType());
        }

    }
}
