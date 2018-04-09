using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Mal.XF.Infra.Behaviors
{
    public class ResponsiveGridBehavior : BehaviorBase<Grid>
    {
        public int SmallWidth { get; set; } = 768;
        public int MediumWidth { get; set; } = 992;
        public int LargeWidth { get; set; } = 1200;

        private enum GridWidth
        {
            ExtraSmall,
            Small,
            Medium,
            Large,
            Undefined
        }

        private GridWidth actualGridWidth = GridWidth.Undefined;

        protected override void OnAttachedTo(Grid grid)
        {
            base.OnAttachedTo(grid);

            this.AssociatedObject.SizeChanged += this.ResponsiveGrid_SizeChanged;
            this.AssociatedObject.VerticalOptions = LayoutOptions.Start;

            for (var i = 0; i < 12; i++)
                this.AssociatedObject.ColumnDefinitions.Add(new ColumnDefinition());
        }

        protected override void OnDetachingFrom(Grid grid)
        {
            base.OnDetachingFrom(grid);
            this.AssociatedObject.SizeChanged -= this.ResponsiveGrid_SizeChanged;
        }

        private void ResponsiveGrid_SizeChanged(object sender, EventArgs e)
        {
            var gridWidth = this.GetAvailableWidth();

            if (gridWidth == this.actualGridWidth)
                return;

            this.actualGridWidth = gridWidth;

            var row = 0;
            const int maxColspan = 12;

            this.AssociatedObject.RowDefinitions.Clear();
            this.AssociatedObject.RowDefinitions.Add(new RowDefinition());

            var rows = this.GetAvailableResponsiveRows();

            for (var i = 0; i < rows.Count; i++)
            {
                var responsiveRow = rows[i];
                var column = 0;
                var children = this.GetChildrenByRow(responsiveRow);
                for (var j = 0; j < children.Count; j++)
                {
                    var child = children[j];

                    var columnSpan = this.GetChildColumnSpan(child, gridWidth);
                    Grid.SetColumnSpan(child, columnSpan);
                    Grid.SetColumn(child, column);
                    Grid.SetRow(child, row);
                    column += columnSpan;

                    if (column < maxColspan || j >= children.Count - 1)
                        continue;

                    row++;
                    this.AssociatedObject.RowDefinitions.Add(new RowDefinition());
                    column = 0;
                }

                if (i >= rows.Count - 1)
                    continue;

                row++;
                this.AssociatedObject.RowDefinitions.Add(new RowDefinition());
            }
        }

        private IReadOnlyList<int> GetAvailableResponsiveRows()
        {
            var rows = new List<int>();
            foreach (var child in this.AssociatedObject.Children)
            {
                var reponsiveRow = ResponsiveGrid.GetRow(child);
                if (rows.All(r => r != reponsiveRow))
                    rows.Add(reponsiveRow);
            }
            return rows.OrderBy(r => r).ToList();
        }

        private IReadOnlyList<BindableObject> GetChildrenByRow(int row)
        {
            var items = new List<BindableObject>();

            foreach (var child in this.AssociatedObject.Children)
            {
                var reponsiveRow = ResponsiveGrid.GetRow(child);
                if (reponsiveRow == row)
                    items.Add(child);
            }

            return items;
        }

        private GridWidth GetAvailableWidth()
        {
            var container = this.GetContainer();

            var widthInPixel = ScreenHelper.GetDimensionInPixels(container.Width);

            if (widthInPixel >= LargeWidth)
                return GridWidth.Large;

            if (widthInPixel >= MediumWidth)
                return GridWidth.Medium;

            if (widthInPixel >= SmallWidth)
                return GridWidth.Small;

            return GridWidth.ExtraSmall;
        }

        private View GetContainer()
        {
            return this.AssociatedObject;
        }

        private int GetChildColumnSpan(BindableObject child, GridWidth gridWidth)
        {
            var large = ResponsiveGrid.GetLarge(child);
            var medium = ResponsiveGrid.GetMedium(child);
            var small = ResponsiveGrid.GetSmall(child);
            var extraSmall = ResponsiveGrid.GetExtraSmall(child);

            switch (gridWidth)
            {
                case GridWidth.ExtraSmall:
                    return extraSmall ?? small ?? medium ?? large ?? 1;

                case GridWidth.Small:
                    return small ?? extraSmall ?? medium ?? large ?? 1;

                case GridWidth.Medium:
                    return medium ?? small ?? extraSmall ?? large ?? 1;

                case GridWidth.Large:
                    return large ?? medium ?? small ?? extraSmall ?? 1;

                default:
                    return 1;
            }
        }
    }
}
