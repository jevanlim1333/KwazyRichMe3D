// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using Coherence.ProtocolDef;
    using Coherence.Serializer;
    using Coherence.Brook;
    using Coherence.Entities;
    using Coherence.Log;
    using Coherence.Core;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnityEngine;

    public struct GenericCommand : IEntityCommand
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Interop
        {
            [FieldOffset(0)]
            public ByteArray name;
            [FieldOffset(16)]
            public ByteArray commandData;
            [FieldOffset(32)]
            public Entity entityParam1;
            [FieldOffset(36)]
            public Entity entityParam2;
            [FieldOffset(40)]
            public Entity entityParam3;
            [FieldOffset(44)]
            public Entity entityParam4;
        }

        public static unsafe GenericCommand FromInterop(System.IntPtr data, System.Int32 dataSize) 
        {
            if (dataSize != 48) {
                throw new System.Exception($"Given data size is not equal to the struct size. ({dataSize} != 48) " +
                    "for command with ID 6");
            }

            var orig = new GenericCommand();
            var comp = (Interop*)data;
            orig.name = comp->name.Data != null ? System.Text.Encoding.UTF8.GetString((byte*)comp->name.Data, comp->name.Length) : null;
            orig.commandData = new byte[comp->commandData.Length]; Marshal.Copy((System.IntPtr)comp->commandData.Data, orig.commandData, 0, comp->commandData.Length);
            orig.entityParam1 = comp->entityParam1;
            orig.entityParam2 = comp->entityParam2;
            orig.entityParam3 = comp->entityParam3;
            orig.entityParam4 = comp->entityParam4;
            return orig;
        }

        public System.String name;
        public System.Byte[] commandData;
        public Entity entityParam1;
        public Entity entityParam2;
        public Entity entityParam3;
        public Entity entityParam4;
        
        public Entity Entity { get; set; }
        public MessageTarget Routing { get; set; }
        public uint Sender { get; set; }
        public uint GetComponentType() => 6;
        
        public IEntityMessage Clone()
        {
            // This is a struct, so we can safely return
            // a struct copy.
            return this;
        }
        
        public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Coherence.Log.Logger logger)
        {
            var err = mapper.MapToAbsoluteEntity(Entity, false, out var absoluteEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            Entity = absoluteEntity;
            err = mapper.MapToAbsoluteEntity(entityParam1, false, out absoluteEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            entityParam1 = absoluteEntity;
            
            err = mapper.MapToAbsoluteEntity(entityParam2, false, out absoluteEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            entityParam2 = absoluteEntity;
            
            err = mapper.MapToAbsoluteEntity(entityParam3, false, out absoluteEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            entityParam3 = absoluteEntity;
            
            err = mapper.MapToAbsoluteEntity(entityParam4, false, out absoluteEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            entityParam4 = absoluteEntity;
            
            return IEntityMapper.Error.None;
        }
        
        public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Coherence.Log.Logger logger)
        {
            var err = mapper.MapToRelativeEntity(Entity, false, out var relativeEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            Entity = relativeEntity;
            err = mapper.MapToRelativeEntity(entityParam1, false, out relativeEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            entityParam1 = relativeEntity;
            
            err = mapper.MapToRelativeEntity(entityParam2, false, out relativeEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            entityParam2 = relativeEntity;
            
            err = mapper.MapToRelativeEntity(entityParam3, false, out relativeEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            entityParam3 = relativeEntity;
            
            err = mapper.MapToRelativeEntity(entityParam4, false, out relativeEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            entityParam4 = relativeEntity;
            
            return IEntityMapper.Error.None;
        }

        public HashSet<Entity> GetEntityRefs() {
            return new HashSet<Entity> {
                entityParam1,
                entityParam2,
                entityParam3,
                entityParam4,
            };
        }

        public void NullEntityRefs(Entity entity) {
            if (entityParam1 == entity) {
                entityParam1 = Entity.InvalidRelative;
            }
            if (entityParam2 == entity) {
                entityParam2 = Entity.InvalidRelative;
            }
            if (entityParam3 == entity) {
                entityParam3 = Entity.InvalidRelative;
            }
            if (entityParam4 == entity) {
                entityParam4 = Entity.InvalidRelative;
            }
        }
        
        public GenericCommand(
        Entity entity,
        System.String name,
        System.Byte[] commandData,
        Entity entityParam1,
        Entity entityParam2,
        Entity entityParam3,
        Entity entityParam4
)
        {
            Entity = entity;
            Routing = MessageTarget.All;
            Sender = 0;
            
            this.name = name; 
            this.commandData = commandData; 
            this.entityParam1 = entityParam1; 
            this.entityParam2 = entityParam2; 
            this.entityParam3 = entityParam3; 
            this.entityParam4 = entityParam4; 
        }
        
        public static void Serialize(GenericCommand commandData, IOutProtocolBitStream bitStream)
        {
            bitStream.WriteShortString(commandData.name);
            bitStream.WriteBytesList(commandData.commandData);
            bitStream.WriteEntity(commandData.entityParam1);
            bitStream.WriteEntity(commandData.entityParam2);
            bitStream.WriteEntity(commandData.entityParam3);
            bitStream.WriteEntity(commandData.entityParam4);
        }
        
        public static GenericCommand Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
        {
            var dataname = bitStream.ReadShortString();
            var datacommandData = bitStream.ReadBytesList();
            var dataentityParam1 = bitStream.ReadEntity();
            var dataentityParam2 = bitStream.ReadEntity();
            var dataentityParam3 = bitStream.ReadEntity();
            var dataentityParam4 = bitStream.ReadEntity();
    
            return new GenericCommand()
            {
                Entity = entity,
                Routing = target,
                name = dataname,
                commandData = datacommandData,
                entityParam1 = dataentityParam1,
                entityParam2 = dataentityParam2,
                entityParam3 = dataentityParam3,
                entityParam4 = dataentityParam4
            };   
        }
    }

}