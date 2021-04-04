//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DungeonGenerator : MonoBehaviour
//{
//    List<RoomNode> allSpaceNodes = new List<RoomNode>()
//    private int dungeonWidth;
//    private int dungeonLength;

//    public DungeonGenerator(int dungeonWidth, int dungeonLength)
//    {
//        this.dungeonWidth = dungeonWidth;
//        this.dungeonLength = dungeonLength;
//    }

//    public List<Node> CalculateRooms(int maxInterations, int roomWidthMin, int roomLengthMin)
//    {
//        BinarySpacePartitioner bsp = new BinarySpacePartitioner(dungeonWidth, dungeonLength);
//        allSpaceNodes = bsp.PrepareNodesCollection(maxInterations, roomWidthMin, roomLengthMin);
//        List<Node> roomSpaces = StructureHelper.TraverseGraphToExtractLowestLeaves(bsp.RootNode);
//        RoomGenerator roomGenerator = new RoomGenerator(maxInterations, roomLengthMin, roomWidthMin);
//        List<Node> roomList = roomGenerator.GenerateRoomsInAGivenSpaces(roomSpaces);
//        return new List<Node>(allSpaceNodes);
//    }
//}
