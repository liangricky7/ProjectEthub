using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup {
    public enum FitType {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns
    }
    public FitType fitType;
    public int rows;
    public int columns;
    public Vector2 cellSize;
    public Vector2 spacing;

    public bool fitX;
    public bool fitY;

    public override void CalculateLayoutInputHorizontal() {
        base.CalculateLayoutInputHorizontal();

        if (fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform) {
            fitX = true;
            fitY = true;

            float sqrRt = Mathf.Sqrt(transform.childCount);
            rows = Mathf.CeilToInt(sqrRt);
            columns = Mathf.CeilToInt(sqrRt);
        }

        if (fitType == FitType.Width || fitType == FitType.FixedColumns) {
            rows = Mathf.CeilToInt(transform.childCount / (float)columns);
        }

        if (fitType == FitType.Height || fitType == FitType.FixedRows) {
            columns = Mathf.CeilToInt(transform.childCount / (float)rows);
        }
        //get width and height of container
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        //define size of each child
        float cellWidth = (parentWidth / (float)columns) - ((spacing.x / (float)columns) * (columns - 1));
        float cellHeight = (parentHeight / (float)rows) - ((spacing.y / (float)rows) * (rows - 1));

        cellSize.x = fitX ? cellWidth : cellSize.x;
        cellSize.y = fitY ? cellHeight : cellSize.y;

        int columnCount = 0;
        int rowCount = 0;

        for (int i = 0; i < rectChildren.Count; i++) {
            rowCount = i / columns;
            columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = (cellSize.x * columnCount) + (spacing.x * columnCount);
            var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount);

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }
    }
    public override void CalculateLayoutInputVertical() {
    }
    public override void SetLayoutHorizontal() {
    }
    public override void SetLayoutVertical() {
    }
}
