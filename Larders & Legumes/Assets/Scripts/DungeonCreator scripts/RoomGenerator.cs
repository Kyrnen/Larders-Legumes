//using System;
//using System.Collections.Generic;
//using UnityEngine;
//internal class RoomGenerator
//{
//    private int maxInterations;
//    private int roomLengthMin;
//    private int roomWidthMin;

//    public RoomGenerator(int maxInterations, int roomLengthMin, int roomWidthMin)
//    {
//        this.maxInterations = maxInterations;
//        this.roomLengthMin = roomLengthMin;
//        this.roomWidthMin = roomWidthMin;
//    }

//    public List<RoomNode> GenerateRoomsInAGivenSpaces(List<Node> roomSpaces)
//    {
//        List<RoomNode> listToReturn = new List<RoomNode>();
//        foreach (var space in roomSpaces)
//        {
//            Vector2Int newBottomLeftPoint = StructureHelper.GenerateBottomLeftCornerBetween(
//                space.BottomLeftAreaCorner, space.TopRightAreaCorner, 0.1f, 1);
//        }
//    }
//}