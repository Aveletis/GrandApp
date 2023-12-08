namespace GrandApp.ViewModels.Rooms
{
    public class SortRoomsViewModel
    {
        public RoomSortState CodeSort { get; private set; }
        public RoomSortState NameSort { get; private set; }
        public RoomSortState RoomCategorySort { get; private set; }
        public RoomSortState Current { get; private set; }     // текущее значение сортировки

        public SortRoomsViewModel(RoomSortState sortOrder)
        {
            CodeSort = sortOrder == RoomSortState.CodeAsc ?
                RoomSortState.CodeDesc : RoomSortState.CodeAsc;

            NameSort = sortOrder == RoomSortState.NameAsc ?
                RoomSortState.NameDesc : RoomSortState.NameAsc;

            RoomCategorySort = sortOrder == RoomSortState.RoomCategoryAsc ?
                RoomSortState.RoomCategoryDesc : RoomSortState.RoomCategoryAsc;
            Current = sortOrder;
        }
    }
}
