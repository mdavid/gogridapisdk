
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = bin/Debug/GoGrid.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/

GOGRID_DLL_MDB_SOURCE=bin/Debug/GoGrid.dll.mdb
GOGRID_DLL_MDB=$(BUILD_DIR)/GoGrid.dll.mdb

endif

if ENABLE_DEBUG_MIXED_PLATFORMS
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = bin/Debug/GoGrid.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/

GOGRID_DLL_MDB_SOURCE=bin/Debug/GoGrid.dll.mdb
GOGRID_DLL_MDB=$(BUILD_DIR)/GoGrid.dll.mdb

endif

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = bin/Debug/GoGrid.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/

GOGRID_DLL_MDB_SOURCE=bin/Debug/GoGrid.dll.mdb
GOGRID_DLL_MDB=$(BUILD_DIR)/GoGrid.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = bin/Release/GoGrid.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/

GOGRID_DLL_MDB=

endif

if ENABLE_RELEASE_MIXED_PLATFORMS
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = bin/Release/GoGrid.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/

GOGRID_DLL_MDB=

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = bin/Release/GoGrid.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/

GOGRID_DLL_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(GOGRID_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(GOGRID_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	Connection.cs \
	DateRange.cs \
	Endpoint.cs \
	FindLoadBalancer.cs \
	FindServer.cs \
	IModifier.cs \
	IPAddressState.cs \
	IPAddressType.cs \
	JobHistory.cs \
	Job.cs \
	BillingSummary.cs \
	Image.cs \
	Invoker.cs \
	InternalHelper.cs \
	IPAddress.cs \
	JobObjectName.cs \
	JobObjectType.cs \
	JobState.cs \
	LoadBalancer.cs \
	LoadBalancerInterface.cs \
	LoadBalancerPersistence.cs \
	LoadBalancerType.cs \
	Lookup.cs \
	MethodConstants.cs \
	ObjectConstants.cs \
	Option.cs \
	OptionSort.cs \
	Owner.cs \
	Paging.cs \
	PublicHelper.cs \
	Response.cs \
	Server.cs \
	ServerPassword.cs \
	Properties/AssemblyInfo.cs \
	ServerRam.cs \
	ServerType.cs \
	ValueModifier.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	gogrid.pc.in 

REFERENCES =  \
	System \
	System.Core \
	System.Web \
	System.Xml.Linq \
	System.Data.DataSetExtensions \
	System.Data \
	System.Xml

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

GOGRID_PC = $(BUILD_DIR)/gogrid.pc

$(eval $(call emit-deploy-wrapper,GOGRID_PC,gogrid.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
