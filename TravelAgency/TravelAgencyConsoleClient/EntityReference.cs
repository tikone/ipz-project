using System;

namespace TravelAgencyConsoleClient
{
    class EntityReference
    {
        public EntityReference()
        {
            this.ObjectId = -1;
        }

        public bool IsInitialized()
        {
            return ObjectId != -1;
        }

        public void Initialize(int objectId)
        {
            this.ObjectId = objectId;
        }

        public void Drop()
        {
            this.ObjectId = -1;
        }

        public int ObjectId { get; private set; }
    }
}