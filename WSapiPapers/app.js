const { createApp } = Vue;

createApp({
    data() {
        return {
            searchQuery: 'software',
            papers: [],
            loading: false,
            error: null,
            searched: false,
            currentPage: 1,
            itemsPerPage: 10
        };
    },
    computed: {
        totalPages() {
            return Math.ceil(this.papers.length / this.itemsPerPage);
        },
        paginatedPapers() {
            const start = (this.currentPage - 1) * this.itemsPerPage;
            const end = start + this.itemsPerPage;
            return this.papers.slice(start, end);
        }
    },
    mounted() {
        // Realizar una búsqueda inicial
        this.searchPapers();
    },
    methods: {
        async searchPapers() {
            if (!this.searchQuery.trim()) {
                this.error = 'Por favor ingrese un término de búsqueda';
                return;
            }

            this.loading = true;
            this.error = null;
            this.searched = true;

            try {
                const query = encodeURIComponent(this.searchQuery);
                const url = `https://api.plos.org/search?q=title:${query}&wt=json&rows=20`;
                
                const response = await fetch(url);
                
                if (!response.ok) {
                    throw new Error(`Error HTTP: ${response.status}`);
                }

                const data = await response.json();
                
                if (data.response && data.response.docs) {
                    this.papers = data.response.docs;
                    this.currentPage = 1; // Reset a la primera página
                } else {
                    this.papers = [];
                }
            } catch (err) {
                this.error = `Error al buscar papers: ${err.message}`;
                this.papers = [];
            } finally {
                this.loading = false;
            }
        },
        formatDate(dateString) {
            if (!dateString) return 'N/A';
            const date = new Date(dateString);
            return date.toLocaleDateString('es-ES', {
                year: 'numeric',
                month: 'long',
                day: 'numeric'
            });
        },
        getAbstract(abstractArray) {
            if (!abstractArray || abstractArray.length === 0) return 'No disponible';
            return abstractArray[0].substring(0, 200) + '...';
        },
        goToPage(page) {
            if (page >= 1 && page <= this.totalPages) {
                this.currentPage = page;
            }
        },
        previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
            }
        }
    }
}).mount('#app');
