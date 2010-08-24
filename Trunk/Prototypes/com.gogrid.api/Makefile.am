
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = bin/Debug/com.gogrid.api.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/

COM_GOGRID_API_DLL_MDB_SOURCE=bin/Debug/com.gogrid.api.dll.mdb
COM_GOGRID_API_DLL_MDB=$(BUILD_DIR)/com.gogrid.api.dll.mdb

endif

if ENABLE_DEBUG_MIXED_PLATFORMS
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = bin/Debug/com.gogrid.api.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/

COM_GOGRID_API_DLL_MDB_SOURCE=bin/Debug/com.gogrid.api.dll.mdb
COM_GOGRID_API_DLL_MDB=$(BUILD_DIR)/com.gogrid.api.dll.mdb

endif

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = bin/Debug/com.gogrid.api.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/

COM_GOGRID_API_DLL_MDB_SOURCE=bin/Debug/com.gogrid.api.dll.mdb
COM_GOGRID_API_DLL_MDB=$(BUILD_DIR)/com.gogrid.api.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = bin/Release/com.gogrid.api.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/

COM_GOGRID_API_DLL_MDB=

endif

if ENABLE_RELEASE_MIXED_PLATFORMS
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = bin/Release/com.gogrid.api.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/

COM_GOGRID_API_DLL_MDB=

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = bin/Release/com.gogrid.api.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/

COM_GOGRID_API_DLL_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(COM_GOGRID_API_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(COM_GOGRID_API_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	Data\ Classes/BillingSummary.cs \
	Data\ Classes/Ip.cs \
	Data\ Classes/Messages.cs \
	Data\ Classes/Option.cs \
	GlobalVariables.cs \
	GridCredentials.cs \
	LoadBalancer\ Data\ Classes/LoadBalancer.cs \
	LoadBalancer\ Data\ Classes/LoadBalancerDS.cs \
	LoadBalancer\ Data\ Classes/Persistence.cs \
	Methods/BillingMethods.cs \
	Methods/IPMethods.cs \
	Methods/LoadBalancerMethods.cs \
	Methods/PasswordMethods.cs \
	Methods/ServerImageMethods.cs \
	Methods/ServerMethods.cs \
	Methods/UtilityMethods.cs \
	Properties/AssemblyInfo.cs \
	Server\ Image\ Data\ Classes/ServerImage.cs \
	Server\ Method\ Data\ Classes/PasswordList.cs \
	Server\ Method\ Data\ Classes/Ram.cs \
	Server\ Method\ Data\ Classes/Server.cs \
	Server\ Method\ Data\ Classes/ServerListDS.cs \
	Server\ Method\ Data\ Classes/ServerOs.cs \
	Server\ Method\ Data\ Classes/ServerState.cs \
	Server\ Method\ Data\ Classes/ServerType.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	com.gogrid.api.pc.in 

REFERENCES =  \
	System \
	System.Data \
	System.Web \
	System.Xml \
	System.Configuration

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

COM_GOGRID_API_PC = $(BUILD_DIR)/com.gogrid.api.pc

$(eval $(call emit-deploy-wrapper,COM_GOGRID_API_PC,com.gogrid.api.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
